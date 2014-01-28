$(document).ready(function () {

});
function ClothesViewModel(clothes, isEdit) {
    var self = this;
    self.Id = clothes.Id;
    self.Code = clothes.Code;
    self.Name = clothes.Name;
    self.Price = clothes.Price;
    self.shouldDisplayEdit = ko.observable(isEdit);

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


    self.edit = function(product) {
        product.setShouldDisplayEdit(false);
    };

};


var viewModel = new ViewModel();
InitBindings(viewModel);
ko.applyBindings(viewModel);
