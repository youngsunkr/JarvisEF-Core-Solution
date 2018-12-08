(function (hunet) {
    var _hunet = hunet;
    this.options = {
        callBack: null
    };
    hunet.AWSTransCoding = function () {
        var that = this;

        this.curSendCnt = 0;
        this.authorizationToken = null;
        //this.SubmittedCount = [];
        //this.IsFileUpload = false;

        hunet.AWSTransCoding.prototype.GetAuthorization.call();
    }
    hunet.AWSTransCoding.prototype.GetAuthorization = function () {
        var access_token = '';

        try {

            var param = '';

            //console.log('호출전');

            hunet.prototype.ajaxCall('', '/TourMaker/GetAuthorization', 'post', 'json', param, function (objJson) {

                if (objJson.length > 0) {
                    //console.log(objJson.access_token);
                    eval("result = " + objJson);
                    //alert(result.access_token);
                    access_token = result.access_token;
                    authorizationToken = result.access_token;

                    if (result.access_token != '' && result != 'undefined') {

                        // 인증 완료후 작업

                        // 1. 트랜스파일 파일 업로드
                        // 2. 트랜스파일 상세 정보
                        // 3. 트랜스파일 삭제

                        //alert('파일 업로드 시작');
                        //console.log(access_token);
                        //authorizationToken = access_token;
                    }
                }
            });

            return access_token;

        } catch (e) {
            //alert("인증 실패!!");
            //return null;
        }
    };


    var result = null;
    hunet.AWSTransCoding.prototype.SubmittedCount = [];
    hunet.AWSTransCoding.prototype.IsFileUpload = false;

    hunet.AWSTransCoding.prototype.SetUpload = function (asyncType, formData, requestSiteCode) {
        var that = this;

        console.log(authorizationToken);
        var IsSuccess = false;
        hunet.AWSTransCoding.prototype.IsFileUpload = false;
        
        hunet.AWSTransCoding.prototype.SubmittedCount.push(requestSiteCode);
        //console.log(authorizationToken);
        //console.log("추가된 배열 값 : " + hunet.AWSTransCoding.prototype.SubmittedCount.length);
        
        //var param = "conversionSeq=" + result.requestSiteCode + "&successFlag=N&transcodingId=UI_UPLOAD_START&transcodingState=UI_UPLOAD_START";
        //hunet.prototype.ajaxCall('', '/Common/TransCoding_UploadComplete', 'post', false, param, function (data) { });

        $.ajax({
            url: "https://api.prod.hunet.name/media/v1/transcoding",
            type: "POST",
            async: asyncType,
            //enctype: 'multipart/form-data',
            contentType: false,
            processData: false,
            data: formData,
            cache: false,
            //beforeSend: function (xhr) {
            //    xhr.setRequestHeader('authorization', 'Bearer ' + authorizationToken);
            //    xhr.setRequestHeader('accept', '*/*');
            //    //xhr.setRequestHeader('Content-Type', 'multipart/form-data');
            //
            //    //var file = data.files[0];
            //    //xhr.setRequestHeader('multipartFile', formData);
            //},
            headers: {
                "authorization": "Bearer " + authorizationToken
                , "accept": "*/*"
                //, "Content-Type": "multipart/form-data"
            },
            success: function (result) {

                console.log(result.requestSiteCode);
                console.log(result.transcodingId);
                console.log(result.transcodingState);

                
                /* 추후 배포(업로드중 창닫기 & 화면이동)
                     Contents.cshtml 페이지의 "beforeunload"이벤트도 주석 제거
                     */
                //for (var i = 0; i < hunet.AWSTransCoding.prototype.SubmittedCount.length; i++) {
                //    console.log("배열 삭제전 값 : " + hunet.AWSTransCoding.prototype.SubmittedCount[i]);
                //}
                
                hunet.AWSTransCoding.prototype.SubmittedCount.splice(
                    hunet.AWSTransCoding.prototype.SubmittedCount.indexOf(result.requestSiteCode), 1);    //dog,cat,seal,lion,cat
                
                //console.log("배열카운트 : " + hunet.AWSTransCoding.prototype.SubmittedCount.length);
                //for (var i = 0; i < hunet.AWSTransCoding.prototype.SubmittedCount.length; i++) {
                //    console.log("배열카운트 값 : " + hunet.AWSTransCoding.prototype.SubmittedCount[i]);
                //}


                // 업로드 성공시 성공 로그 저장

                var param = "conversionSeq=" + result.requestSiteCode + "&successFlag=Y&transcodingId=" + result.transcodingId + "&transcodingState=" + result.transcodingState;
                hunet.prototype.ajaxCall('', '/Common/TransCoding_UploadComplete', 'post', false, param, function (data) {

                    //Submitted = $.grep(hunet.AWSTransCoding.prototype.SubmittedCount, function (element, index) {
                    //    console.log("검색값: " + result.requestSiteCode);
                    //    if ($.inArray(result.requestSiteCode, hunet.AWSTransCoding.prototype.SubmittedCount) > -1) {
                    //        hunet.AWSTransCoding.prototype.SubmittedCount.splice(hunet.AWSTransCoding.prototype.SubmittedCount.indexOf(index), 1);
                    //            //return true;
                    //    }
                    //});

                    //Submitted = $.grep(hunet.AWSTransCoding.prototype.SubmittedCount, function (element, index) {
                    //   return arrRequestSiteCode.splice(result.requestSiteCode) != -1;
                    //);

                    //Submitted = $.grep(hunet.AWSTransCoding.prototype.SubmittedCount, function (value) {
                    //    //console.log("배열 삭제전 값" + hunet.AWSTransCoding.prototype.SubmittedCount);
                    //    return value != result.requestSiteCode;
                    //});

                    
                });

                hunet.AWSTransCoding.prototype.IsFileUpload = true;
                IsSuccess = true;

                return IsSuccess;

            },
            error: function (jqXHR, status, errorThrown) {

                //console.log("code:" + jqXHR.status);
                //console.log("message" + jqXHR.responseText);
                //console.log(error);
                //console.log(status);

                //alert(hunet.AWSTransCoding.prototype.SubmittedCount.length);
                
                
                var param = "conversionSeq=" + requestSiteCode + "&successFlag=N&transcodingId=UPLOAD_FAIL&transcodingState=ERROR";
                hunet.prototype.ajaxCall('',
                    '/Common/TransCoding_UploadComplete',
                    'post',
                    false,
                    param,
                    function(data) {
                    });
                // 운영시에는 오류 메시지를 사용자 친화적으로 변경 하여 출력할것
                alert("동영상 업로드에 실패 하였습니다.");

                hunet.AWSTransCoding.prototype.SubmittedCount.splice(
                    hunet.AWSTransCoding.prototype.SubmittedCount.indexOf(requestSiteCode), 1);    //dog,cat,seal,lion,cat

                //alert(hunet.AWSTransCoding.prototype.SubmittedCount.length);

                console.log("배열카운트" + hunet.AWSTransCoding.prototype.SubmittedCount.length);
                for (var i = 0; i < hunet.AWSTransCoding.prototype.SubmittedCount.length; i++) {
                    console.log("배열카운트 값" + hunet.AWSTransCoding.prototype.SubmittedCount[i]);
                }


                hunet.AWSTransCoding.prototype.IsFileUpload = false;
                IsSuccess = false;

                return IsSuccess;
            }

        });
    }

    hunet.AWSTransCoding.prototype.ajaxCall = function (obj, url, type, asyncType, cache, dataType, data, callBack) {
        
        var that = this;

        //console.log(authorizationToken);
        
        $.ajax({
            url: url,
            type: type,
            async: asyncType,
            contentType: false,
            processData: false,
            dataType: processData,
            data: data,
            cache: cache,
            headers: {
                "authorization": "Bearer " + authorizationToken
                , "accept": "*/*"
            },
            beforeSend: function () {
                if (obj != null && typeof (obj) == "object") {

                    if (Hunet.prototype.customIndicator(obj))
                        return;

                    if (obj.attr('id') == "__loading__")
                        obj.html("<div style='position:fixed; top:50%; left:50%; z-index:99999;'><img src='/Common/indicator/loading.gif' /></div>");
                    else
                        obj.html("<div style='width:100%; text-align:center; height:100%; vertical-align:middle;'><img src='/common/indicator/loading.gif' /></div>");
                }
                else if (obj && (obj == "__loading_layout_show__" || obj == "__loading_layout_show_hide__")) {
                    hunet.showLoadingLayout();
                }
            },
            success: function (result) {

                console.log(result.requestSiteCode);
                console.log(result.transcodingId);
                console.log(result.transcodingState);

                if (obj != null && typeof (obj) == "object") {
                    if (obj.attr('id') == "__loading__") {
                        obj.html("");
                        obj.hide();
                    }
                }
                else if (obj && obj == "__loading_layout_show_hide__") {
                    hunet.hideLoadingLayout();
                }

                if (typeof (data) == 'string'
                    && data.indexOf('http://img.hunet.co.kr/hunet/common/error/access-block.jpg') > 0
                    && data.indexOf('접속 차단 - 웹 보안 정책 위반') > 0) {

                    var accessBlockHtml = "<div class='popup-wrap-bg' style='height: 100%;'></div><div id='popup-wrap' class='popup-type800 popup-fixed' ><div class='popup-inner'><div id='popup-content'>";
                    accessBlockHtml += data.replace(/<(\/a|a)([^>]*)>/gi, "").replace(/<(\/img|img)([^>]*)>/gi, "");
                    accessBlockHtml += "</div></div></div>";

                    if ($('#__layer__').length == 0) {
                        $(document.body).append($("<div id='__layer__'></div>"));
                    }
                    $('#__layer__').html(accessBlockHtml);
                    return;
                }

                if (callBack != undefined && typeof (callBack) == "function") {
                    callBack(data);
                } else {
                    if (obj != null && typeof (obj) == "object") {
                        if ($.browser.msie) {
                            var expr = new RegExp('>[ \t\r\n\v\f]*<', 'g');
                            obj.html((data + "").replace(expr, '> <'));
                        } else {
                            obj.html(data);
                        }
                    }
                }
                //hunet.resizeLeftMenu(); //왼쪽 메뉴 리사이즈   
            },
            error: function (jqXHR, status, errorThrown) {

                //console.log("code:" + jqXHR.status);
                //console.log("message" + jqXHR.responseText);
                //console.log(error);
                //console.log(status);

                //"http://img.hunet.co.kr/hunet/common/error/access-block.jpg";

                if (obj != null && typeof (obj) == "object") {
                    if (obj.attr('id') == "__loading__") {
                        obj.html("");
                        obj.hide();
                    }
                }
                else if (obj && (obj == "__loading_layout_show__" || obj == "__loading_layout_show_hide__")) {
                    hunet.hideLoadingLayout();
                }

                if (status == "abort") return;
                if (callBack != undefined && typeof (callBack) == "function") {
                    //callBack("페이지 오류");
                    callBack("");
                } else {
                    if (obj != null && typeof (obj) == "object")
                    //obj.html("페이지 오류");
                        obj.html("");
                }
                //alert("code : " + request.status + "\r\nmessage : " + request.responseText);

                if (typeof (request.responseText) == 'string'
                    && request.responseText.indexOf('http://img.hunet.co.kr/hunet/common/error/access-block.jpg') > 0
                    && request.responseText.indexOf('접속 차단 - 웹 보안 정책 위반') > 0) {

                    var accessBlockHtml = "<div class='popup-wrap-bg' style='height: 100%;'></div><div id='popup-wrap' class='popup-type800 popup-fixed' ><div class='popup-inner'><div id='popup-content'>";
                    accessBlockHtml += data.replace(/<(\/a|a)([^>]*)>/gi, "").replace(/<(\/img|img)([^>]*)>/gi, "");
                    accessBlockHtml += "</div></div></div>";

                    if ($('#__layer__').length == 0) {
                        $(document.body).append($("<div id='__layer__'></div>"));
                    }
                    $('#__layer__').html(accessBlockHtml);
                }
            }

        });
    }

    hunet.AWSTransCoding.prototype.GetExtension = function(filename) {
        var parts = filename.split('.');
        return parts[parts.length - 1];
    };
    hunet.AWSTransCoding.prototype.IsVideo = function(filename) {
        var ext = this.GetExtension(filename);
        switch (ext.toLowerCase()) {
        case "avi":
        case "mpeg":
        case "mpg":
        case "mkv":
        case "mp4":
        case "wmv":
        case "asf":
        case "flv":
        case "mov":
            // etc
            return true;
        }
        return false;
    };


})(Hunet);