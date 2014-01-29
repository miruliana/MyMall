$(document).ready(function () {

});


ko.validation.init({
    decorateElement: true,
    errorElementClass: 'err',
    insertMessages: false
});

ko.validation.rules['mustBeNumberOrDecimal'] = {
    validator: function (val, flag) {
        return TestValidDecimal(val, flag);
    },
    message: 'The field must be a decimal number!'
};
ko.validation.registerExtenders();

function ClothesViewModel(clothes, isEdit) {
    var self = this;
    self.Id = clothes.Id;
    self.Code = ko.observable(clothes ? clothes.Code : '').extend({ required: true, maxLength: 10, minLength: 2 });
    self.Name = ko.observable(clothes ? clothes.Name : '').extend({ required: false, maxLength: 255, minLength: 0 });
    self.Price = ko.observable(clothes ? clothes.Price : '').extend({ mustBeNumberOrDecimal: true });

    self.shouldDisplayEdit = ko.observable(isEdit);

    self.setShouldDisplayEdit = function (flag) {
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
        var clothesErrors = ko.validation.group(product, { deep: true });
        if (clothesErrors().length > 0) {
            return;
        }
        $.ajax({
            url: baseURI + 'Put/' + product.Id,
            cache: false,
            type: 'PUT',
            contentType: 'application/json; charset=utf-8',
            data: ko.toJSON(product), //JSON.stringify(product),
            success: function () {
                product.setShouldDisplayEdit(true);
                self.getAll();
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
            Code: product.Code._latestValue,
            Name: product.Name._latestValue,
            Price: product.Price._latestValue
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
InitBindings(viewModel);
ko.applyBindings(viewModel);