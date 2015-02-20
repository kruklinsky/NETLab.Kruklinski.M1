var site = site || {};
site.authentication = (function () {
    showAuthenticatingContent = function () {
        js.$("login").hidden = true;
        js.$("logout").hidden = true;
        js.$("menu").hidden = true;
        js.$("header__logs__loading").hidden = false;
    };
    changeAuthenticationContent = function (isAuthenticated) {
        hideAuthenticatingContent();
        if (isAuthenticated) {
            js.$("login").hidden = true;
            js.$("logout").hidden = false;
            js.$("menu").hidden = false;
        }
        else {
            js.$("login").hidden = false;
            js.$("logout").hidden = true;
            js.$("menu").hidden = true;
        }
    };
    hideAuthenticatingContent = function () {
        js.$("header__logs__loading").hidden = true;
    };
    return {
        onLogin: function () {
            showAuthenticatingContent();
            authentication.ajaxFormsAuth.login(js.$("login__form"), site.authentication.checkAuthentication)
            js.$("login__form").password.value = "";
            return false;
        },
        onLogout: function () {
            showAuthenticatingContent();
            authentication.ajaxFormsAuth.logout(js.$("logout__form"), site.authentication.checkAuthentication);
            return false;
        },
        checkAuthentication: function () {
            authentication.ajaxFormsAuth.checkAuthentication(changeAuthenticationContent);
        }
    }
})();
site.jsonTree = (function () {
    function onLoad(response) {
        var jsonTreeHtml = jsonTree.build(JSON.parse(response));
        var div = document.createElement('div');
        div.innerHTML = jsonTreeHtml;
        replace("jsonTree", div);
    };
    function replace(id, node) {
        var result = js.$(id);
        clear(result);
        result.appendChild(node);
        result.hidden = false;
    };
    function clear(node) {
        while (node.firstChild) {
            node.removeChild(node.firstChild);
        }
    };
    return {
        load: function () {
            js.ajax.submit("cs.json", "GET", onLoad)
        }
    }
})();

document.addEventListener("DOMContentLoaded", function (event) {
    js.$("login__form").onsubmit = site.authentication.onLogin;
    js.$("logout__form").onsubmit = site.authentication.onLogout;
    js.$("menu__load-button").addEventListener("click", site.jsonTree.load)
    site.authentication.checkAuthentication();
});




