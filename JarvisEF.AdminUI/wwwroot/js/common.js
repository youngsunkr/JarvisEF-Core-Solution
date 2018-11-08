Common = {};

Common.format = function(text) {
    if (arguments.length <= 1) {
        return text;
    }
    var tokenCount = arguments.length - 2;
    for (var token = 0; token <= tokenCount; token++) {
        text = text.replace(new RegExp("\\{" + token + "\\}", "gi"),
            arguments[token + 1]);
    }
    return text;
};

Common.escapeHTML = function(str) {
    str = str.replace(/&/g, "&amp;");
    str = str.replace(/</g, "&lt;");
    str = str.replace(/>/g, "&gt;");

    return str;
};

Common.formatDate = function (date, formatString) {
    var tempDateString;
    tempDateString = formatString.replace("yyyy", date.getFullYear());
    tempDateString = tempDateString.replace("MM", date.getMonth() + 1);
    tempDateString = tempDateString.replace("dd", date.getDate());

    return tempDateString;
}

Common.showProgressBox = function(message) {
    $("#progressBox").modal({
        close: false,
        position: ["20%",],
        overlayId: 'modalBackground',
        containerId: 'modalContainer',
        onShow: function(dialog) {
            dialog.data.find('#message').append(message);
            dialog.data.find('#close').click(function() {
                $.modal.close();
            });
        }
    });
};

var stringEscape = {
    '\b': '\\b',
    '\t': '\\t',
    '\n': '\\n',
    '\f': '\\f',
    '\r': '\\r',
    '"': '\\"',
    '\\': '\\\\'
};

//// Escape 문자들을 대응되는 일반 문자열로 변환한다.
//// \r과 같은 캐리지 리턴을 \\r이라는 문자열로 바꿔서 json 사용 시 문제가 없도록 한다.
//// 이렇게 보내면, 서버에서는 올바로 \r (캐리지 리턴)으로 인식한다.
//Common.replaceJSONSafeEscape = function(string) {
//    return string
//        .replace(
//            /[\x00-\x1F\x7F-\x9F]/g,
//            function(a) {
//                var b = stringEscape[a];
//                if (b)
//                    return b;
//                else
//                    return a;
//            }
//        );
//};

Common.queryString = function (name) {
    var q = location.search.replace(/^\?/, '').replace(/\&$/, '').split('&');
    for (var i = q.length - 1; i >= 0; i--) {
        var p = q[i].split('='), key = p[0], val = p[1];
        if (name.toLowerCase() === key.toLowerCase()) return val;
    }

    return "";
};