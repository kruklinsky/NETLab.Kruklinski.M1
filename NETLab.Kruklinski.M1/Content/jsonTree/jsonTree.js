var jsonTree = (function () {
    function parse(json, prop) {
        var result = "";
        var value = json[prop];
        switch (typeof (value)) {
            case "object":
                result +=
                "<li class='node expandClosed'>\
                    <div class='expand'></div>\
                    <div class='content'>"+ prop + "</div>\
                    <ul class='jsonTree'>"
                        + parseJson(json[prop]) +
                    "</ul>\
                </li>"
                break;
            default:
                result +=
                "<li class='node expandLeaf'>\
                    <div class='expand'></div>\
                    <div class='content'>"+ prop + ": " + value + "</div>\
                </li>"
        }
        return result;
    };
    function parseJson(json) {
        var result = "";
        for (prop in json) {
            result += parse(json, prop);
        }
        return result;
    };
    function hasClass(elem, className) {
        return new RegExp("(^|\\s)" + className + "(\\s|$)").test(elem.className)
    };
    function cumulativeOffset (element) {
        var top = 0, left = 0;
        do {
            top += element.offsetTop || 0;
            left += element.offsetLeft || 0;
            element = element.offsetParent;
        } while (element);

        return {
            top: top,
            left: left
        };
    };
    return {
        onToggle: function (event) {
            event = event || window.event
            var clickedElem = event.target || event.srcElement
            if (!hasClass(clickedElem, 'expand')) {
                return
            }
            var node = clickedElem.parentNode
            if (hasClass(node, 'expandLeaf')) {
                return
            }
            var newClass = hasClass(node, 'expandOpen') ? 'expandClosed' : 'expandOpen';
            var re = /(^|\s)(expandOpen|expandClosed)(\s|$)/;
            node.className = node.className.replace(re, '$1' + newClass + '$3');
        },
        build: function (json) {
            var result =
                "<div onclick='jsonTree.onToggle(arguments[0])'>\
                    <div class='jsonTree content'>Root</div>\
                    <ul class='jsonTree'>";
                        result += parseJson(json);
         result += "</ul>\
                </div> </div>";
            return result;
        }
    }
})();




