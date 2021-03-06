﻿$(document).ready(function () {

});
ko.validation.init({
    decorateElement: true,
    errorElementClass: 'err',
    insertMessages: false
});

ko.extenders.requiredValidation = function (target, message) {
    target.hasError = ko.observable();
    target.validationMessage = ko.observable();
    target.lastValidValue = ko.observable();
 
    function validate(newValue) {
     
        if (newValue.length > 10 || newValue.length < 2) {
            target.hasError(true);
            target.validationMessage(message);
        }
        else {
            target.hasError(false);
            target.validationMessage("");
        }

    }
    function setInitialValueIfValid() {
        if (!target.hasError()) {
            target.lastValidValue(target());
        }
    }
   

    validate(target());
    setInitialValueIfValid();
    target.subscribe(validate);
    return target;
};

ko.extenders.requiredDecimalValidation = function (target, message) {
    target.hasError = ko.observable();
    target.validationMessage = ko.observable();
    target.lastValidValue = ko.observable();

    function validate(newValue) {
        if (!TestValidDecimal(newValue, true)) {
            target.hasError(true);
            target.validationMessage(message);
        }
        else {
            target.hasError(false);
            target.validationMessage("");
        }

    }
    function setInitialValueIfValid() {
        if (!target.hasError()) {
            target.lastValidValue(target());
        }
    }
    
    validate(target());
    setInitialValueIfValid();
    target.subscribe(validate);
    return target;
};
//ko.validation.rules['mustBeNumberOrDecimal'] = {
//    validator: function (val, flag) {
//        return TestValidDecimal(val, flag);
//    },
//    message: 'The field must be a decimal number!'
//};
ko.validation.registerExtenders();

function ClothesViewModel(clothes, isEdit) {
    var self = this;
    self.Id = clothes.Id;
    self.Code = ko.observable(clothes ? clothes.Code : '').extend({ requiredValidation: "Code must be at least 2 characters!" });
    self.Name = clothes.Name;
    self.Price = ko.observable(clothes ? clothes.Price : '').extend({ requiredDecimalValidation: "Price must have a decimal value" });
    self.shouldDisplayEdit = ko.observable(isEdit);
    self.hasErrors = ko.computed(function () { return self.Code.hasError() || self.Price.hasError(); });
    
    self.setShouldDisplayEdit = function(flag) {
        self.shouldDisplayEdit(flag);
    };
  
}


function InitBindings(viewModel) {
    viewModel.getAll();
}

function ViewModel() {
    var self = this;
    var baseURI = "/api/ClothesApi/";
    self.clothesProducts = ko.observableArray();
    self.clothes = ko.observable();
    self.status = ko.observable();
    self.links = ko.observable();
   

    self.getAll = function () {
        self.clothesProducts.removeAll();
        $.getJSON(baseURI + 'Get', function (clothesProducts) {
            $.each(clothesProducts, function (index, clothes) {
                self.clothesProducts.push(new ClothesViewModel(clothes, true));
            });
        });
    };
    
    self.update = function (product) {
        self.status("");
       // var clothesErrors = ko.validation.group(product, { deep: true });
        if (product.hasErrors()) {
            return;
        }
        $.ajax({
                url: baseURI + 'Put/' + product.Id,
                cache: false,
                type: 'PUT',
                contentType: 'application/json; charset=utf-8',
                data: ko.toJSON(product), //JSON.stringify(product),
                success: function() {
                    product.setShouldDisplayEdit(true);
                    self.getAll();
                }
            })
                .fail(
                    function(xhr, textStatus, err) {
                        self.status(err);
                    });
        
    };

    self.create = function () {
        self.status("");
        var product = {
            Code: $('#code2').val(),
            Name: $('#name2').val(),
            Price: $('#price2').val()
        };
        if (!isValidProduct(product.Code, product.Name, product.Price)) {
            alert("Please add all fields correctly!");
            return;
        }
        
        $.ajax({
            url: baseURI + 'Post',
            cache: false,
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            data: ko.toJSON(product),//JSON.stringify(product),
            statusCode: {
                201 /*Created*/: function (data) {
                    self.clothesProducts.push(new ClothesViewModel(data, true));
                  
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
        self.oldProduct = {
            Code: product.Code._latestValue != undefined ? product.Code._latestValue: product.Code ,
            Name: product.Code._latestValue != undefined ? product.Name._latestValue : product.Name,
            Price: product.Code._latestValue != undefined ? product.Price._latestValue : product.Price
        };
        product.setShouldDisplayEdit(false);
    };
    
    self.cancel = function (product) {
            if (self.oldProduct != undefined) {
            if (self.oldProduct.Code != undefined)
                product.Code(self.oldProduct.Code);
            if (self.oldProduct.Name != undefined)
                product.Name(self.oldProduct.Name);
            if (self.oldProduct.Price != undefined)
                product.Price(self.oldProduct.Price);
        
        }
        product.setShouldDisplayEdit(true);
    };
    
};


var viewModel = new ViewModel();
InitBindings(viewModel);
ko.applyBindings(viewModel);
