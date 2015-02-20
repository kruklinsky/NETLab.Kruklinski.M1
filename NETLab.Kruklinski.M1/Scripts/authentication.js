var authentication = authentication || {};
authentication.ajaxFormsAuth = (function () {
    var checkAuthenticationAction = "/Account/Authenticated";
    var checkAuthenticationMethod = "GET";
    return {
        login: function (form, onLoad) {
            js.ajax.submitForm(form, onLoad);
        },
        logout: function (form, onLoad) {
            js.ajax.submitForm(form, onLoad);
        },
        checkAuthentication: function (onLoad_isAuthenticated) {
            js.ajax.submit(checkAuthenticationAction, checkAuthenticationMethod, function (response) {
                onLoad_isAuthenticated(response == "true");
            });
        }
    }
})();