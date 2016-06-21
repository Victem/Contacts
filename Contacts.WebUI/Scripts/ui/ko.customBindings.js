;(function () {
    ko.bindingHandlers.image = {
        update: function (element, valueAccessor, allBindings, viewModel, bindingContext) {

            var value = valueAccessor();
            var valueUnwrapped = ko.unwrap(value);          
           
            if (valueUnwrapped === "null" || valueUnwrapped === undefined) {
                element.src = element.dataset["defaultImage"];
                return;
            }

            if ((valueUnwrapped !== "null") && (valueUnwrapped !== undefined)) {
                element.src = valueUnwrapped;
                return;
            }           
        }
    }





    ko.bindingHandlers.imageInput = {
        
        update: function (element, valueAccessor, allBindings) {

            var img = document.getElementById(allBindings.get('targetImg'));            
            var value = valueAccessor();
            console.log(value());
            var form = element.form;
            var inputFileButton = form.querySelector(allBindings.get('inputButton'));

            inputFileButton.addEventListener("click", function (e) {
                if (element) {

                    element.click();
                }
                e.preventDefault();
            }, false);


            element.addEventListener("change", function (e) {

                var file = e.target.files[0];
                var fileReader = new FileReader();
                fileReader.addEventListener("load", function (image) {
                    return function (e) {                        
                        if (img.src !== img.dataset["defaultImage"])                            
                            value(e.target.result);
                            
                        }                

                }(img));
                fileReader.readAsDataURL(file);

            });
        }        
    }
}());