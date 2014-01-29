//ko.bindingHandlers.readOnly = {
//    update: function (element, valueAccessor) {
//        var value = ko.utils.unwrapObservable(valueAccessor());
//        if (value) {
//            element.setAttribute("readOnly", true);
//        } else {
//            element.removeAttribute("readOnly");
//        }
//    }
//}
//ko.bindingHandlers.forEachWithTotalLength = {
//    init: function (element, valueAccessor, allBindingsAccessor, viewModel, context) {
//        return ko.bindingHandlers.foreach.init(element, valueAccessor, allBindingsAccessor, viewModel, context);
//    },
//    update: function (element, valueAccessor, allBindingsAccessor, viewModel, context) {
//        var array = ko.utils.unwrapObservable(valueAccessor());
//        var extendedContext = context.extend({ "$length": viewModel.clothesProductsLength });
//        ko.bindingHandlers.foreach.update(element, valueAccessor, allBindingsAccessor, viewModel, extendedContext);
//    }
//};

