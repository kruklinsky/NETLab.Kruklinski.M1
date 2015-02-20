var js = js || {};
js.ajax = (function () {
    getXmlHttp = function () {
        var result = null;
        if (window.XMLHttpRequest) {
            result = new XMLHttpRequest();
        }
        else {
            result = new ActiveXObject("Microsoft.XMLHTTP");
        }
        return result;
    };
    return {
        submitForm: function (form, onLoad) {
            var xmlHttp = getXmlHttp();
            xmlHttp.onload = onLoad;
            xmlHttp.open(form.method, form.action, true);
            xmlHttp.send(new FormData(form));
        },
        submit: function (action, method, onLoad_response) {
            var xmlHttp = getXmlHttp();
            xmlHttp.onload = function () {
                onLoad_response(xmlHttp.response);
            }
            xmlHttp.open(method, action, true);
            xmlHttp.send();
        }
    }
})();
js.$ = function (id) {
    return document.getElementById(id);
};