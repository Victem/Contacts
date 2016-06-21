(function () {

    var Contact = function (data) {
		this.id = ko.observable(data.id);
		this.first_name = ko.observable(data.first_name);
		this.last_name = ko.observable(data.last_name);
		this.company_name = ko.observable(data.company_name);
		this.job_title = ko.observable(data.job_title);
		this.email = ko.observable(data.email);
		this.phone = ko.observable(data.phone);
		this.gender = ko.observable(data.gender);        
		this.avatar = ko.observable(data.avatar + "" === "null"
                                    ? data.avatar = "null"
                                    : data.avatar);
		this.fullName = ko.computed(function () {
			return this.first_name() + " " + this.last_name();
		}, this);


        var self = this;
		
		self.showOptions = ko.observable(false);
		
	}


    function ContactsListViewModel() {		
        var self = this;
        var contactToAdd = new Contact({});
        var contactToEdit = new Contact({});
        self.contacts = ko.observableArray([]);
        self.isContactsHidden = ko.observable(true);
        self.isEditContactHidden=ko.observable(false)
        self.newContact = ko.observable(contactToAdd);
        self.editContact = ko.observable(contactToEdit);
        self.lastContact = ko.observable();

        

		loadData("");	


		self.addContactPanelSwitcher = function () {			
		    self.isContactsHidden(!self.isContactsHidden());
		}


		self.showContactEditPanel = function (contact) {
            
		    self.isEditContactHidden(!self.isEditContactHidden());
		    self.showContactOptions(contact);
		    contactToAdd = contact;

		    self.editContact(contact);
		    
		}


		self.hideContactEditPanel = function () {
		    self.isEditContactHidden(!self.isEditContactHidden());
		}

		self.showContactOptions = function (contact) {
            
		    var lastContact = self.lastContact();
		    		    
		    if (lastContact !== undefined) {		        
		        if (lastContact === contact) {
		            lastContact.showOptions(!contact.showOptions());
		            self.lastContact(undefined);
		            return;
		        }
		        else {
		            contact.showOptions(!contact.showOptions());
		            lastContact.showOptions(!lastContact.showOptions());
		            self.lastContact(contact);
		            return;
		        }

		    }
		    else {		        
		        contact.showOptions(!contact.showOptions());
		        self.lastContact(contact);
		    }
            
		}


		self.search = function (data, e) {
			var search = e.originalEvent.currentTarget.value;
			loadData(search);
		}

		self.deleteContact = function (contact) {		   
		    $.ajax({
		        url: "api/contacts/"+ contact.id(),
		        type: "delete",		        
		        success: function (response) {
		            self.contacts.remove(contact);
		        }
		    });		    
		}


		self.addContact = function () {
		    var form = document.forms["addNew"];

		    

		    $.ajax({
		        url: "/api/contacts/",
		        type: "post",
		        data: $(form).serialize(),
		        success: function (response) {
		           
		            contactToAdd.id(response.id);		           
		            self.contacts.push(contactToAdd);
		            contactToAdd = new Contact({})
		            self.newContact(contactToAdd);
		        }
		    });


		}

		self.updateContact = function () {
		    
		    var form = document.forms["editContact"];
		    self.editContact().avatar = form["Avatar"].value;
		    $.ajax({
		        url: "/api/contacts/" + self.editContact().id(),
		        type: "put",
		        data: $(form).serialize(),
		        success: function (responce) {
		            self.hideContactEditPanel();		            

		        }
		        
		    });

		}

		function loadData(search) {

			$.getJSON("/api/contacts/", { searchString: search }, function (data) {				
				var mappedContacts = $.map(data, function (item) {				    
				    var contact = new Contact(item);				   
				    return contact;
				});

				self.contacts.slice();
				self.contacts(mappedContacts);

			});
		}	
	}
	

	ko.applyBindings(new ContactsListViewModel());
}());

