/// <reference path="DataPaging.js" />
/// <reference path="jquery.form.js" />
/// <reference path="jquery-1.8.2.min.js" />
/// <reference path="Jquery.json.js" />
/// <reference path="smohan.blog.plug.js" />
YF.DataAccess = {};

YF.DataAccess.Admin = function () { };

YF.DataAccess.MenuBar = function () { };
YF.DataAccess.MenuBar.prototype.GetList = function (o, cb) {
    $.ajax({
        url: YF.Config.DefaultSiteUrl + 'API/Student/StudentAdd.ashx',
        type: "post",
        dataType: "json",
        data: o,
        success: function (result) {
            cb(result.status);
        }
    });
};