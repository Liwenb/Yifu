var ArticleList = {

    //页数
    PageIndex: 1,
    //数量
    PageSize: 30,
    //分页数据
    PageData: [],
    //初始化
    Init: function () {

        ArticleList.LoadData();
    },

    /**
     * 分页查询
     * @param PageIndex 页数
     */
    PageSelect: function (pageIndex) {

        var pageContent = $('#list');

        var postData = {};
        ArticleList.PageIndex = pageIndex;
        postData.PageIndex = ArticleList.PageIndex;
        postData.PageSize = ArticleList.PageSize;

        $.ajax({
            type: "Post",
            data: postData,
            url: "/API/Article/GetListPage/",
            success: function (res) {
                //App.unblockUI(pageContent);
                if (res.Code == 1) {
                    //ArticleList.PageData = res;
                    ArticleList.PageData = res;
                    ArticleList.LoadData();
                } else {
                    alert(res.Message);
                }
            },
            error: function (a, b, c) {
                //App.unblockUI(pageContent);
            }
        });
    },

    //加载数据
    LoadData: function () {
        $("#tbody_Data").html("");
        if (ArticleList.PageData.Data.length == 0) {
            $("#tbody_Data").append("<div style=\"text-align: center;\">暂无数据</div>");
        }

        //加载分页
        $("#div_Page").html(ArticleList.PageData.Page);

        //循环加载列表
        $(ArticleList.PageData.Data).each(function (index, item) {
            var html = $($("#template_Web").text()).clone();
            html.find('a').html("● " + item.cat_body_title).attr("href", YF.Config.DefaultSiteUrl + "Article/Article/" + item.cat_body_id);

            $("#tbody_Data").append(html);
        });
    },
};