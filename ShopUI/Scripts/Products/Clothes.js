$(document).ready(function () {

});

ko.validation.init({
    decorateElement: true,
    errorElementClass: 'err',
    insertMessages: false,
    messageTemplate: 'myCustomTemplate'
});

ko.validation.rules['mustBeNumberOrDecimal'] = {
    validator: function (val, flag) {
        return TestValidDecimal(val, flag);
    },
    message: 'The field must be a decimal number!'
};
ko.validation.registerExtenders();


function Brand(id, name) {
    var self = this;
    self.Id = ko.observable(id);
    self.Name = ko.observable(name);
}
function Category(id, name) {
    var self = this;
    self.Id = ko.observable(id);
    self.Name = ko.observable(name);
}
function Destination(id, name) {
    var self = this;
    self.Id = ko.observable(id);
    self.Name = ko.observable(name);
}
function ProductsViewModel(product, isEdit) {
    var self = this;
    self.Id = product.Id;
    self.Code = ko.observable(product ? product.Code : '').extend({ required: true, maxLength: 10, minLength: 2 });
    self.Name = ko.observable(product ? product.Name : '').extend({ required: false, maxLength: 255, minLength: 0 });
    self.Price = ko.observable(product ? product.Price : '').extend({ mustBeNumberOrDecimal: true });
    self.BrandId = ko.observable(product ? product.BrandId : '').extend({ required: true });
    self.CategoryId = ko.observable(product ? product.CategoryId : '').extend({ required: true });
    self.shouldDisplayEdit = ko.observable(isEdit);

    self.setShouldDisplayEdit = function (flag) {
        self.shouldDisplayEdit(flag);
    };
}


function InitBindings(viewModel) {
    viewModel.getAll();
    viewModel.getAllBrands();
    viewModel.getAllCategories();
}

function ViewModel() {
    var self = this;
    var baseURI = "/api/ClothesApi/";
    var baseBrandsURI = "/api/BrandsApi/";
    var baseCategoryURI = "/api/CategoryApi/";
    var baseDestinationURI = "/api/DestinationApi/";
    self.clothesProducts = ko.observableArray();
    self.clothes = ko.observable();
    self.status = ko.observable();
    self.links = ko.observable();
    self.brands = ko.observableArray();
    self.categories = ko.observableArray();
    self.destinations = ko.observableArray();
    self.myBrandSelectedOption = ko.observable();
    self.myCategorySelectedOption = ko.observable();
    self.errorMessage = ko.observable("");
    
    self.resetProduct = function(product) {
        $.ajax({
            url: baseURI + 'GetById/' + product.Id,
            cache: false,
            type: 'GET',
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                product.Code(data.Code);
                product.Name(data.Name);
                product.Price(data.Price);
                product.BrandId(data.BrandId);
                product.CategoryId(data.CategoryId);
            }
        })
       .fail(
              function (xhr, textStatus, err) {
                  self.status(err);
              });
    };

    self.getAll = function () {
        self.errorMessage("");
        self.clothesProducts.removeAll();
        $.getJSON(baseURI + 'Get', function (clothesProducts) {
            $.each(clothesProducts, function (index, clothes) {
                self.clothesProducts.push(new ProductsViewModel(clothes, true));
            });
        });
    };
    self.getAllBrands = function () {
        self.brands.removeAll();
        $.getJSON(baseBrandsURI + 'Get', function (brands) {
            $.each(brands, function (index, value) {
                self.brands.push(new Brand(value.Id, value.Name));
            });
        });
    };
  

    self.getAllCategories = function () {
        self.categories.removeAll();
        $.getJSON(baseCategoryURI + 'Get', function (categories) {
            $.each(categories, function (index, value) {
                self.categories.push(new Category(value.Id, value.Name));
            });
        });
    };
    
    self.getDestinations = function () {
        self.destinations.removeAll();
        $.getJSON(baseDestinationURI + 'Get', function (destinations) {
            $.each(destinations, function (index, value) {
                self.destinations.push(new Destination(value.Id, value.Name));
            });
        });
    };
    
    self.update = function (product) {
        self.status("");
        var clothesErrors = ko.validation.group(product, { deep: true });
        if (clothesErrors().length > 0) {
            return;
        }
        self.errorMessage("");
        $.ajax({
            url: baseURI + 'Put/' + product.Id,
            cache: false,
            type: 'PUT',
            contentType: 'application/json; charset=utf-8',
            data: ko.toJSON(product), //JSON.stringify(product),
            success: function () {
                product.setShouldDisplayEdit(true);
             //   self.getAll();
            }
        })
                .fail(
                    function (xhr, textStatus, err) {
                        self.status(err);
                    });

    };

    self.create = function () {
        self.status("");
        var product = {
            Code: $('#code2').val(),
            Name: $('#name2').val(),
            Price: $('#price2').val(),
            BrandId: $('#brand2').val(),
            CategoryId: $('#category2').val()
            
        };
        var message = {val : ""};
        if (!isValidProduct(product.Code, product.Name, product.Price, product.BrandId, product.CategoryId, message)) {
            self.errorMessage(message.val);
            return;
        }
        self.errorMessage("");
        $.ajax({
            url: baseURI + 'Post',
            cache: false,
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            data: ko.toJSON(product),//JSON.stringify(product),
            statusCode: {
                201 /*Created*/: function (data) {
                    self.clothesProducts.push(new ProductsViewModel(data, true));

                }
            }
        })
            .fail(
                function (xhr, textStatus, err) {
                    self.status(err);
                });
    };



    self.remove = function (product) {
        self.status("");
        self.errorMessage("");
        var id = product.Id;
        $.ajax({
            url: baseURI + 'Delete/' + id,
            cache: false,
            type: 'DELETE',
            contentType: 'application/json; charset=utf-8',
            statusCode: {
                204 /*Deleted*/: function () {
                    self.clothesProducts.remove(product);
                }
            }
        })
        .fail(
               function (xhr, textStatus, err) {
                   self.status(err);
               });
    };


    self.edit = function (product) {
        self.errorMessage("");
        product.setShouldDisplayEdit(false);
    };

    self.cancel = function (product) {
        self.errorMessage("");
        self.resetProduct(product);
        product.setShouldDisplayEdit(true);
    
    };

    self.getErrorMessage = function (product) {
        var messagesArray = "";
        var clothesErrors = ko.validation.group(product, { deep: true });
        if (clothesErrors != undefined && clothesErrors._latestValue != undefined) {
            ko.utils.arrayForEach(clothesErrors._latestValue, function (value) {
                if (value._latestValue!= undefined)
                    messagesArray =  messagesArray  + "\n" + value._latestValue;
            
            });
        }
        self.errorMessage(messagesArray);
     
    };

};


var viewModel = new ViewModel();
ko.bindingHandlers.returnAction = {
    init: function (element, valueAccessor, allBindingsAccessor, viewModel) {
        var value = ko.utils.unwrapObservable(valueAccessor());

        $(element).keydown(function (e) {
            if (e.which === 13) {
                value(viewModel);
            }
        });
    }
};

ko.bindingHandlers.autoComplete = {
    findSelectedItem: function (dataSource, binding, selectedValue) {
        var unwrap = ko.utils.unwrapObservable;
        //Go through the source and find the id, and use its label to set the autocomplete
        var source = unwrap(dataSource);
        var valueProp = unwrap(binding.optionsValue);

        var selectedItem = ko.utils.arrayFirst(source, function (item) {
            if (unwrap(item[valueProp]) === selectedValue)
                return true;
        }, this);

        return selectedItem;
    },
    buildDataSource: function (dataSource, labelProp, valueProp) {
        var unwrap = ko.utils.unwrapObservable;
        var source = unwrap(dataSource);
        var mapped = ko.utils.arrayMap(source, function (item) {
            var result = {};
            result.label = labelProp ? unwrap(item[labelProp]) : unwrap(item).toString();  //show in pop-up choices
            result.value = valueProp ? unwrap(item[valueProp]) : unwrap(item).toString();  //value 
            return result;
        });
        return mapped;
    },
    init: function (element, valueAccessor, allBindingsAccessor, viewModel, context) {
        var unwrap = ko.utils.unwrapObservable;
        var dataSource = valueAccessor();
        var binding = allBindingsAccessor();
        var valueProp = unwrap(binding.optionsValue);
        var labelProp = unwrap(binding.optionsText) || valueProp;
        var displayId = $(element).attr('id') + '-display';
        var index = context.$index;
        if (index != undefined)
            displayId = $(element).attr('id') + "_" + index._latestValue + '-display';
       
        var displayElement;
        var options = {};

        if (binding.autoCompleteOptions) {
            options = $.extend(options, binding.autoCompleteOptions);
        }

        //Create a new input to be the autocomplete so that the label shows
        // also hide the original control since it will be used for the value binding
        $(element).hide();
        $(element).after('<input type="text" id="' + displayId + '" />');
        displayElement = $('#' + displayId);

        //handle value changing
        var modelValue = binding.value;
        if (modelValue) {
            var handleValueChange = function (event, ui) {
                var labelToWrite = ui.item ? ui.item.label : null;
                var valueToWrite = ui.item ? ui.item.value : null;
                //The Label and Value should not be null, if it is
                // then they did not make a selection so do not update the 
                // ko model
                if (labelToWrite && valueToWrite) {
                    if (ko.isWriteableObservable(modelValue)) {
                        //Since this is an observable, the update part will fire and select the 
                        //  appropriate display values in the controls
                        modelValue(valueToWrite);
                    } else {  //write to non-observable
                        if (binding['_ko_property_writers'] && binding['_ko_property_writers']['value']) {
                            binding['_ko_property_writers']['value'](valueToWrite);
                            //Because this is not an observable, we have to manually change the controls values
                            // since update will not do it for us (it will not fire since it is not observable)
                            displayElement.val(labelToWrite);
                            $(element).val(valueToWrite);
                        }
                    }
                }
                    //They did not make a valid selection so change the autoComplete box back to the previous selection
                else {
                    var currentModelValue = unwrap(modelValue);
                    //If the currentModelValue exists and is not nothing, then find out the display
                    // otherwise just blank it out since it is an invalid value
                    if (!currentModelValue)
                        displayElement.val('');
                    else {
                        //Go through the source and find the id, and use its label to set the autocomplete
                        var selectedItem = ko.bindingHandlers.autoComplete.findSelectedItem(dataSource, binding, currentModelValue);

                        //If we found the item then update the display
                        if (selectedItem) {
                            var displayText = labelProp ? unwrap(selectedItem[labelProp]) : unwrap(selectedItem).toString();
                            displayElement.val(displayText);
                        }
                            //if we did not find the item, then just blank it out, because it is an invalid value
                        else {
                            displayElement.val('');
                        }
                    }
                }

                return false;
            };

            var handleFocus = function (event, ui) {
                $(displayElement).val(ui.item.label);
                return false;
            };

            options.change = handleValueChange;
            options.select = handleValueChange;
            options.focus = handleFocus;
            //options.close = handleValueChange;
        }

        //handle the choices being updated in a Dependant Observable (DO), so the update function doesn't 
        // have to do it each time the value is updated. Since we are passing the dataSource in DO, if it is
        // an observable, when you change the dataSource, the dependentObservable will be re-evaluated
        // and its subscribe event will fire allowing us to update the autocomplete datasource
        var mappedSource = ko.dependentObservable(function () {
            return ko.bindingHandlers.autoComplete.buildDataSource(dataSource, labelProp, valueProp);
        }, viewModel);
        //Subscribe to the knockout observable array to get new/remove items
        mappedSource.subscribe(function (newValue) {
            displayElement.autocomplete("option", "source", newValue);
        });

        options.source = mappedSource();

        displayElement.autocomplete(options);
    },
    update: function (element, valueAccessor, allBindingsAccessor, viewModel, context) {
        //update value based on a model change
        var unwrap = ko.utils.unwrapObservable;
        var dataSource = valueAccessor();
        var binding = allBindingsAccessor();
        var valueProp = unwrap(binding.optionsValue);
        var labelProp = unwrap(binding.optionsText) || valueProp;
        var displayId = $(element).attr('id') + '-display';
        var index = context.$index;
        if (index != undefined)
            displayId = $(element).attr('id') + "_" + index._latestValue + '-display';
        
        
        var displayElement = $('#' + displayId);
        var modelValue = binding.value;

        if (modelValue) {
            var currentModelValue = unwrap(modelValue);
            //Set the hidden box to be the same as the viewModels Bound property
            $(element).val(currentModelValue);
            //Go through the source and find the id, and use its label to set the autocomplete
            var selectedItem = ko.bindingHandlers.autoComplete.findSelectedItem(dataSource, binding, currentModelValue);
            if (selectedItem) {
                var displayText = labelProp ? unwrap(selectedItem[labelProp]) : unwrap(selectedItem).toString();
                displayElement.val(displayText);
            }
        }
    }
};
InitBindings(viewModel);
ko.applyBindings(viewModel);