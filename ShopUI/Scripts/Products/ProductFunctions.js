
function isValidProduct(code, name, price) {
    if (code.length < 2)
        return false;
    if (!TestValidDecimal(price, true))
        return false;
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
