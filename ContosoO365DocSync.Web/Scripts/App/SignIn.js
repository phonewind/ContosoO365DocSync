$(function () {
    Office.initialize = function (reason) {
        $(document).ready(function () {
            var isDev = window.location.href.indexOf("localhost") > -1;
            var mode = { word: false, excel: false, powerPoint: false };
            if (Office.context.requirements.isSetSupported("WordApi")) {
                mode.word = true;
            }
            else if (Office.context.requirements.isSetSupported("ExcelApi")) {
                mode.excel = true;
            }
            else if (Office.context.requirements.isSetSupported("ActiveView")) {
                mode.powerPoint = true;
            }

            if (mode.word || mode.excel || mode.powerPoint) {
                if (isDev || (Office.context.document.url
                    && (Office.context.document.url.toUpperCase().indexOf("HTTP") > -1 || Office.context.document.url.toUpperCase().indexOf("HTTPS") > -1))) {
                    if ((Office.context.requirements.isSetSupported('ExcelApi', 1.3) && mode.excel) || (Office.context.requirements.isSetSupported("WordApi", 1.2) && mode.word) || mode.powerPoint) {
                        $(".sign-in").show();
                        $("#btnSignIn").click(function () {
                            $(".loading-login").show();
                            if (mode.word) {
                                window.location = "/Word/Point";
                            }
                            else if (mode.excel) {
                                window.location = "/Excel/Point";
                            }
                            else if (mode.powerPoint) {
                                window.location = "/PowerPoint/Point";
                            }
                        });
                    }
                    else {
                        $("#error-message").addClass(mode.word ? "word-version" : "excel-version");
                    }
                }
                else {
                    $("#error-message").addClass(mode.word ? "word-mode" : (mode.excel ? "excel-mode" : "powerpoint-mode"));
                }
            }
        });
    };
});