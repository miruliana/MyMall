
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

function TestValidEmail(val, flag) {
    if (((/^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$/).test(val) == false) && (flag == true))
        return false;
    return true;
}

function isValidAccount(username, email, password, confirmPassword, message) {
    if (username.length < 2 || username.length > 25) {
        message.val = "Username length must be at least 2 characters and no longer than 25!";
        return false;
    }
    if (!TestValidEmail(email, true)) {
        message.val = "The email is invalid!";
        return false;
    }
    if (password != confirmPassword) {
        message.val = "The two passwords do not match!";
        return false;
    }
        
    if (password.length < 6 || password.length > 25) {
        message.val = "Password length must be at least 6 characters and no longer than 25!";
        return false;
    }
   
    return true;
}
