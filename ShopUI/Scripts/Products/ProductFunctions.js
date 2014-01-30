
function isValidProduct(code, name, price, brandId, categoryId, message) {
    if (code.length < 2) {
        message.val = "Code must be at least 2 characters!";
        return false;
    }
        
    if (!TestValidDecimal(price, true)) {
        message.val = "Price must be a decimal number!";
        return false;
    }
    if (brandId == "") {
        message.val = "Brand is mandatory!";
        return false;
    }
    if (categoryId == "") {
        message.val = "Category is mandatory!";
        return false;
    }
    return true;
}

function TestValidDecimal(val, flag) {
    if (((/^[.0-9]+$/).test(val) == false) && (flag == true))
        return false;
    if (isNaN(parseFloat(val)) && (flag == true)) {
        return false;
    }
    return true;
}
