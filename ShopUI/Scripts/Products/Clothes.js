
function ClothesViewModel(clothes) {
    var self = this;
    self.Id = clothes.Id;
    self.Code = clothes.Code;
    self.Name = clothes.Name;
    self.Price = clothes.Price;
}

function ToggleEditUpdate(id, forEdit) {

       $("tr#" + id + " td ").each(function ()
        {
            if ($(this).attr("id") == "edit")
            {
                if (forEdit)
                    $(this).removeClass('inlineVisible').addClass('inlineHidden');
                else
                    $(this).removeClass('inlineHidden').addClass('inlineVisible');
     
            }
            if ($(this).attr("id") == "update")
            {
                if (forEdit)
                    $(this).removeClass('inlineHidden').addClass('inlineVisible');
                else
                    $(this).removeClass('inlineVisible').addClass('inlineHidden'); 
        
            }
        });

    $("tr#" + id + " td input").each(function () {
        if ($(this).attr("id") != "Id") {
            if (forEdit) {
                $(this).removeAttr('readonly');
                $(this).removeClass('readonlyInline');
            }
            else {
                $(this).attr('readonly', true);
                $(this).addClass('readonlyInline');
            }
        }
    });

};

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
                self.clothesProducts.push(new ClothesViewModel(clothes));
            });
        });
    };
 
    self.update = function (product) {
        self.status("");
        var id = product.Id;
      
        $.ajax({
            url: baseURI + 'Put/' + id,
            cache: false,
            type: 'PUT',
            contentType: 'application/json; charset=utf-8',
            data: ko.toJSON(product), //JSON.stringify(product),
            success: function () {
                ToggleEditUpdate(id, false);
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
                    self.clothesProducts.push(new ClothesViewModel(data));
                  
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
        ToggleEditUpdate(product.Id, true);
    };

};


var viewModel = new ViewModel();
viewModel.getAll();
ko.applyBindings(viewModel);
