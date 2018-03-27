
using Raven.Rpc.IContractModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace YiFuSchool.Web
{
    /// <summary>
    /// 接口结果返回
    /// </summary>
    public class LappResponse<T> : ResponseModel<T, Code>
    {
        /// <summary>
        /// 返回状态
        /// </summary>
        public override Code Code
        {
            get
            {
                return base.Code;
            }

            set
            {
                base.Code = value;
            }
        }

        /// <summary>
        /// 返回数据
        /// </summary>
        public override T Data
        {
            get
            {
                return base.Data;
            }

            set
            {
                base.Data = value;
            }
        }
        /// <summary>
         /// 当前条件下数据的数量
         /// </summary>
        public long Count { get; set; }

        /// <summary>
        /// 分页信息
        /// </summary>
        public string Page { get; set; }

        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }


        public string TitleName { get; set; }

        /// <summary>
        /// 返回状态描述
        /// </summary>
        public override string Message
        {
            get
            {
                return base.Message;
            }

            set
            {
                base.Message = value;
            }
        }
    }

    /// <summary>
    /// 接口结果返回
    /// </summary>
    public class LappResponse : ResponseModel<Code>
    {
        /// <summary>
        /// 返回状态
        /// </summary>
        public override Code Code
        {
            get
            {
                return base.Code;
            }

            set
            {
                base.Code = value;
            }
        }

        /// <summary>
        /// 返回状态描述
        /// </summary>
        public override string Message
        {
            get
            {
                return base.Message;
            }

            set
            {
                base.Message = value;
            }
        }
    }

    public enum Code : int
    {
        /// <summary>
        /// 无意义的，防止某些序列化工具在序列化时报错
        /// </summary>
        [Description("无意义的，防止某些序列化工具在序列化时报错")]
        None = 0,

        /// <summary>
        /// 未知
        /// </summary>
        [Description("未知")]
        Unknown = -1,

        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        Success = 1,

        /// <summary>
        /// 失败
        /// </summary>
        [Description("失败")]
        Failure = 2,

        /// <summary>
        /// 参数错误
        /// </summary>
        [Description("参数错误")]
        ParameterError = 3,

        /// <summary>
        /// 暂无数据
        /// </summary>
        [Description("暂无数据")]
        DataIsNull = 6,

        /// <summary>
        /// 服务器异常，请稍后再试
        /// </summary>
        [Description("服务器操作异常，请稍后再试")]
        ServiceError = 601,

        /// <summary>
        /// 没有登录
        /// </summary>
        [Description("您尚未登录，请先登录后再进行操作")]
        NotLogin = 602,

        /// <summary>
        /// 请求过于频繁
        /// </summary>
        [Description("请求过于频繁，您在{0}秒内无法再次操作，请稍后再试！")]
        TooFrequentRequest = 603,

        /// <summary>
        /// 数据已经存在
        /// </summary>
        [Description("您输入的数据已经存在，请仔细检查")]
        DataAlreadyExists = 604,

        /// <summary>
        /// 商务服务名称不能为空
        /// </summary>
        [Description("商务服务名称不能为空")]
        BusineServiceNameNotEmpty = 605,

        /// <summary>
        /// 券名称不能为空
        /// </summary>
        [Description("券名称不能为空")]
        VoucherNameNotEmpty = 606,

        /// <summary>
        /// 副标题不能为空
        /// </summary>
        [Description("副标题不能为空")]
        SubtitleNotEmpty = 607,

        /// <summary>
        /// 卡券颜色不能为空
        /// </summary>
        [Description("卡券颜色不能为空")]
        VoucherColorNotEmpty = 608,

        /// <summary>
        /// 减免金额不能为空
        /// </summary>
        [Description("减免金额不能为空")]
        ReduceMoneyNotEmpty = 609,

        /// <summary>
        /// 修改条件不能为空
        /// </summary>
        [Description("修改条件不能为空")]
        ModifyConditionNotEmpty = 610,

        /// <summary>
        /// 操作提示不能为空
        /// </summary>
        [Description("操作提示不能为空")]
        OperationTipsNotEmpty = 611,

        /// <summary>
        /// 使用须知不能为空
        /// </summary>
        [Description("使用须知不能为空")]
        UseDescNotEmpty = 612,

        /// <summary>
        /// 数据不存在
        /// </summary>
        [Description("数据不存在")]
        DataEmpty = 613,

        /// <summary>
        /// 上传的文件没有数据
        /// </summary>
        [Description("上传的文件没有数据")]
        FileNotEmpty = 614,

        /// <summary>
        /// 券未领取，无法核销
        /// </summary>
        [Description("券未领取，无法核销")]
        NotReceive = 615,

        /// <summary>
        /// 券已经被核销过，无法再次核销
        /// </summary>
        [Description("券已经被核销过，无法再次核销")]
        Used = 616,

        /// <summary>
        /// 已过期
        /// </summary>
        [Description("已过期")]
        Expire = 617,

        /// <summary>
        /// 数据异常，请联系开发人员
        /// </summary>
        [Description("数据异常，请联系开发人员")]
        DataError = 618,

        /// <summary>
        /// 数据导入成功，库存修改失败
        /// </summary>
        [Description("数据导入成功，库存修改失败")]
        ImportSuccessStoreCountUpdateFailure = 619,

        /// <summary>
        /// 折扣额度必须在1 - 9.9之间
        /// </summary>
        [Description("折扣额度必须在1 - 9.9之间")]
        DiscountAmountError = 620,

        /// <summary>
        /// 请选择优惠内容，并输入相关优惠信息
        /// </summary>
        [Description("请选择优惠内容，并输入相关优惠信息")]
        PreferentialNotEmpty = 621,

        /// <summary>
        /// 核销成功，核销统计失败
        /// </summary>
        [Description("核销成功，核销统计失败")]
        VerifySuccessStatisticsError = 622,

        /// <summary>
        /// 商场ID不能为空
        /// </summary>
        [Description("商场ID不能为空")]
        MallIDNotEmpty = 623,

        /// <summary>
        /// 验证码不存在或已过期
        /// </summary>
        [Description("验证码不存在或已过期")]
        VCodeIsNullOrExpried = 624,

        /// <summary>
        /// 库存不够
        /// </summary>
        [Description("库存不够")]
        StockNotEnough = 625,

        /// <summary>
        /// 不在使用时间范围内
        /// </summary>
        [Description("不在使用时间范围内")]
        TimeIsYetToCome = 626,

        /// <summary>
        /// 手机号码不能为空
        /// </summary>
        [Description("手机号码不能为空")]
        MobileNotEmpty = 627,

        /// <summary>
        /// 当前数据的数量小于需要被删除的数量
        /// </summary>
        [Description("当前数据的数量小于需要被删除的数量")]
        DataIsLessThanTheNumberOfDeleted = 628,

        /// <summary>
        /// 库存恢复失败
        /// </summary>
        [Description("库存恢复失败")]
        RestoreFailed = 629,

        /// 固定日期不能小于之前的时间范围
        /// </summary>
        [Description("开始时间不能晚于之前设定的时间，且结束时间不能早于之前设定的时间")]
        BuNengXiaoYuShangCiXuanZeDeShiJianFanWei = 630,

        /// <summary>
        /// 猫酷系统创建成功，创建微信卡券失败
        /// </summary>
        [Description("猫酷系统创建成功，创建微信卡券失败")]
        CreateWXCardFailed = 631,

        /// <summary>
        /// 猫酷系统更新成功，更新微信卡券失败
        /// </summary>
        [Description("猫酷系统更新成功，更新微信卡券失败")]
        WXCardUpdateFailed = 632,

        /// <summary>
        /// 核销口令错误
        /// </summary>
        [Description("核销口令错误")]
        VerifyPasswordError = 633,

        /// <summary>
        /// 未启用口令核销功能
        /// </summary>
        [Description("未启用口令核销功能")]
        VerifyPasswordDisable = 634,

        /// <summary>
        /// 尚未开通此类券的口令核销功能
        /// </summary>
        [Description("尚未开通此类券的口令核销功能")]
        VerifyPasswordNotSupported = 635,

        /// <summary>
        /// 当日领取库存不足
        /// </summary>
        [Description("当日领取库存不足")]
        EDGetInventoryShortage = 636,

        /// <summary>
        /// 用户领取库存不足
        /// </summary>
        [Description("用户领取库存不足")]
        UserGetInventoryShortage = 637,

        /// <summary>
        /// 已经领取过
        /// </summary>
        [Description("已经领取过")]
        CouponReceive = 638,

        /// <summary>
        /// 抵消停车时长必须为整数
        /// </summary>
        [Description("抵消停车时长必须是整数")]
        InsteadTimeIsNotInt = 639,

        /// <summary>
        /// 抵消停车费必须为两位有效数字
        /// </summary>
        [Description("抵消停车费必须为两位有效数字")]
        InsteadMoneyOnly2DecimalDigits = 640,

        /// <summary>
        /// 核销商户错误
        /// </summary>
        [Description("核销商户错误")]
        VerificationShopError = 641,

        /// <summary>
        /// 当前券已经被删除
        /// </summary>
        [Description("当前券已经被删除")]
        CouponDelete = 642,

        /// <summary>
        /// 编辑时，开始日期不能小于当前时间.
        /// </summary>
        [Description("开始日期不能小于当前时间")]
        BeginBuNengXiaoYuNow = 643,

        /// </summary>
        /// 编辑固定日期的结束日期不能小于当前时间
        /// </summary>
        [Description("编辑固定日期的结束日期不能小于当前时间")]
        EndBuNengXiaoYuNow = 644,

        /// <summary>
        /// 获取微信公众号临时二维码失败，请重试
        /// </summary>
        [Description("获取微信公众号临时二维码失败，请重试")]
        GetWXQrCodeFailure = 645,

        /// <summary>
        /// 请选择核销类型
        /// </summary>
        [Description("请选择核销类型")]
        VerificationTypeCheckFail = 646,

        /// <summary>
        /// 投放失败，此券类型已经被投放过
        /// </summary>
        [Description("投放失败，此券类型已经被投放过")]
        PutInError = 647,

        /// <summary>
        /// 没有发券的权限
        /// </summary>
        [Description("没有发券的权限")]
        NotSendCouponPower = 648,

        /// <summary>
        /// 含有非正常或非冻结状态的券
        /// </summary>
        [Description("含有非正常或非冻结状态的券")]
        HasExecpCoupon = 649,

        /// <summary>
        /// 含有不可退的券
        /// </summary>
        [Description("含有不可退的券")]
        NotCancelCoupon = 650,

        /// <summary>
        /// 团购撤销状态修改失败
        /// </summary>
        [Description("团购撤销状态修改失败")]
        CouponCancelError = 651,

        /// <summary>
        /// 团购撤销库存还原失败
        /// </summary>
        [Description("团购撤销库存还原失败")]
        CouponStockCancelError = 652,

        /// <summary>
        /// 团购撤销数量还原失败
        /// </summary>
        [Description("团购撤销数量还原失败")]
        CouponCancelCountError = 653,

        /// <summary>
        /// 追踪ID不能为空
        /// </summary>
        [Description("追踪ID不能为空")]
        TraceIDNotEmpty = 654,

        /// <summary>
        /// 标题不能为空
        /// </summary>
        [Description("标题不能为空,请先输入标题")]
        TitleNotEmpty = 656,

        /// <summary>
        /// 请选择至少一张券进行投放
        /// </summary>
        [Description("请选择至少一张券进行投放")]
        PutInCouponNotEmpty = 657,

        /// <summary>
        /// 库存不能为空
        /// </summary>
        [Description("库存不能为空")]
        StockNotEmpty = 658,

        /// <summary>
        /// 数据太多
        /// </summary>
        [Description("数据太多")]
        DataOverflow = 659,

        /// <summary>
        /// 数据模板错误
        /// </summary>
        [Description("数据模板错误")]
        FileTemplateError = 660,

        /// <summary>
        /// 商户编号错误
        /// </summary>
        [Description("商户编号错误")]
        ShopCodeError = 661,

        /// <summary>
        /// 核销商户不能为空，此券为商户券如果需要核销则必须传入ShopID或ShopCode
        /// </summary>
        [Description("核销商户不能为空，此券为商户券如果需要核销则必须传入ShopID或ShopCode")]
        VerificationShopNotEmpty = 662,

        /// <summary>
        /// 小票二维码已被使用
        /// </summary>
        [Description("小票二维码已被使用")]
        STQRCodeUse = 663,

        /// <summary>
        /// 券码错误
        /// </summary>
        [Description("券码错误")]
        VCodeError = 664,

        /// <summary>
        /// 券状态异常无法核销
        /// </summary>
        [Description("券状态异常无法核销")]
        NotVerification = 665,

        /// <summary>
        /// 不允许撤销核销
        /// </summary>
        [Description("不允许撤销核销")]
        NotAllowCancelRecord = 666,

        /// <summary>
        /// 不允许撤销核销
        /// </summary>
        [Description("超出撤销核销时间限制")]
        GtAllowRevokeHours = 667,

        /// <summary>
        /// 不允许撤销核销
        /// </summary>
        [Description("已达撤销核销次数上限")]
        GtAllowRevokeCount = 668,

        #region 积分服务异常编码（2000-2050）

        /// <summary>
        /// 积分超过上限
        /// </summary>
        [Description("积分超过上限")]
        AboveLimit = 2003,

        #endregion
    }
}
