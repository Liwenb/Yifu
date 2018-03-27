var Tool = {
    //判断是否验证
    isVerification: true,
    //加密Key
    Key: "",
    //读取错误提示信息
    GetPageErrorPrompt: function (Code) {
        var msg = $.ajax({
            type: "get", //请求方式
            url: Tool.PostUrl + "JavaScript/PageErrorPrompt.txt?id=14", //地址，就是action请求路径
            dataType: "json", //数据类型text xml json  script  jsonp
            async: false//同步
        });

        msg = $.parseJSON(msg.responseText);
        return msg[Code];
    },
    //更新验证码
    UpdateVerifyCode: function () {
        $("#txt_VerifyCode").val("");
        $("#img_VerifyCode").attr("src", "VerifyCodePage.aspx?ran=" + Math.random());
    },
    //验证密码
    VerificationPassword: function () {
        if (Tool.isVerification) {
            if ($("#txt_LoginPwd").val().length < 8) {
                $("#txt_LoginPwd").focus().select();
                alert("密码不得小于8位！");
            }
        }
    },
    //PostUrl: "http://222.66.158.166:8080/webadmin/",
    //PostUrl: "http://210.13.108.36:8080/webadmin/",
    PostUrl: "http://localhost/FullgoalFundWebAdmin/",
    //时间格式化 格式为：/Date:445552222/
    DateFormat: function (val) {
        if (val != null && val != "") {
            return eval(val.replace(/\/Date\((\d+)\)\//gi, "new Date($1)")).toLocaleDateString();
            //var z = {M:x.getMonth()+1,d:x.getDate(),h:x.getHours(),m:x.getMinutes(),s:x.getSeconds()};
            //y = y.replace(/(M+|d+|h+|m+|s+)/g,function(v) {return ((v.length>1?"0":"")+eval('z.'+v.slice(-1))).slice(-2)});
            //return y.replace(/(y+)/g,function(v) {return x.getFullYear().toString().slice(-v.length)});
        }
    },
    //显示日期的方式  param1:2014-01-02 15:00:00,param2：1=2014-01-02,2=15:00:00
    ShowDateTime: function (param1, param2) {
        param1 = Tool.DateTimeFormat(param1);
        var result = "";
        switch (param2) {
            case "1":
                result = param1.substring(0, 10);
                break;
            case "2":
                result = param1.substring(11, param1.length);
                break;
            default:
                result = "";
                break;
        }
        return result;
    },
    //format="yyyy-MM-dd hh:mm:ss"; 
    DateTimeFormat: function (DateIn) {
        DateIn = DateIn.replace(/\//g, '-');
        var a = DateIn.split(" ");
        var b = a[0].split("-");
        var c = a[1].split(":");
        var date = new Date(b[0], b[1], b[2], c[0], c[1], c[2])
        var Year = 0;
        var Month = 0;
        var Day = 0;
        var Hour = 0;
        var Minute = 0;
        var Second = 0;
        var CurrentDate = "";
        Year = date.getFullYear() == 0 ? 1900 : date.getFullYear();
        Month = date.getMonth() + 1;
        Day = date.getDate();
        Hour = date.getHours();
        Minute = date.getMinutes();
        Second = date.getSeconds();
        CurrentDate = Year + "-";
        if (Month >= 10) {
            CurrentDate = CurrentDate + Month + "-";
        }
        else {
            CurrentDate = CurrentDate + "0" + Month + "-";
        }
        if (Day >= 10) {
            CurrentDate = CurrentDate + Day;
        }
        else {
            CurrentDate = CurrentDate + "0" + Day;
        }
        if (Hour >= 10) {
            CurrentDate = CurrentDate + " " + Hour;
        } else {
            CurrentDate = CurrentDate + " 0" + Hour;
        }
        if (Minute >= 10) {
            CurrentDate = CurrentDate + ":" + Minute;
        }
        else {
            CurrentDate = CurrentDate + ":0" + Minute;
        }
        if (Second >= 10) {
            CurrentDate = CurrentDate + ":" + Second;
        }
        else {
            CurrentDate = CurrentDate + ":0" + Second;
        }
        return CurrentDate;

    },
    //弹出模式对话框
    ShowDialog: function (url) {
        window.showModalDialog(url, '2', 'dialogWidth:1058px;dialogHeight:600px;scroll:no;status:no;menubar:no;');
        //window.location.reload(); 
    },
    NotNull: function (text) {
        return text.trim().length == 0 ? false : true;
    },

    AllSelect: function () {
        if ($("input[type=checkbox]").attr("checked") != "checked") {
            $("input[type=checkbox]").attr("checked", "checked");
        }
        else {
            $("input[type=checkbox]").removeAttr("checked");
        }
    },
    //反选
    OtherSelect: function () {
        $("input[type=checkbox]").each(function () {
            if ($(this).attr("checked") == "checked") {
                $(this).removeAttr("checked");
            }
            else {
                $(this).attr("checked", "checked");
            }
        });
    },

    formatMoney: function (money, digit) {
        var tpMoney = '0.00';
        if (undefined != money) {
            tpMoney = money;
        }
        tpMoney = new Number(tpMoney);
        if (isNaN(tpMoney)) {
            return '0.00';
        }
        tpMoney = tpMoney.toFixed(digit) + '';
        var re = /^(-?\d+)(\d{3})(\.?\d*)/;
        while (re.test(tpMoney)) {
            tpMoney = tpMoney.replace(re, "$1,$2$3")
        }

        return tpMoney;
    },
}

/*
获取指定的URL参数值
URL:http://www.baidu.com?name=55
参数：paramName URL参数
调用方法:GetParam("name")
返回值:55
*/
function GetParam(paramName) {
    var r = new RegExp(paramName + '=([^=&]+)', 'i');
    var mm = window.location.search.match(r);
    if (mm) {
        return mm[1];
    }
    else {
        return null;
    }
}
