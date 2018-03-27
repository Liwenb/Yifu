/// <reference path="DataPaging.js" />
/// <reference path="jquery.form.js" />
/// <reference path="jquery-1.8.2.min.js" />
/// <reference path="Jquery.json.js" />
/// <reference path="smohan.blog.plug.js" />
PH.DataAccess = {};

PH.DataAccess.Admin = function () { };

PH.DataAccess.Student = function () { };
PH.DataAccess.Student.prototype.StudentAdd = function (o, cb) {
    $.ajax({
        url: PH.Config.DefaultSiteUrl + 'Api/Student/StudentAdd.ashx',
        type: "post",
        dataType: "json",
        data: o,
        success: function (result) {
            cb(result.status);
        }
    });
};