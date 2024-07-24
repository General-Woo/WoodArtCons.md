function getCookie(name) {
    var value = "; " + document.cookie;
    var parts = value.split("; " + name + "=");
    if (parts.length === 2) return parts.pop().split(";").shift();
}

//window.removeJwtFromCookie = function () {
//    document.cookie = "token; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
//}
function removeJwtFromCookie(name) {
    document.cookie = '';
    document.cookie = name + '=' + '' + '; expires=' + '' + '; path=/;';
};
