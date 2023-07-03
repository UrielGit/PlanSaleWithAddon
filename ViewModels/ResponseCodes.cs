using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Xml.Linq;

namespace PlanSaleWithAddon.ViewModels
{
    public enum ResponseCodes
    {

        [Display(Name = "Continue")]
        [Description("100 Continue")]
        Continue = 100,

        [Display(Name = "Switching Protocols")]
        [Description("101 Switching Protocols")]
        SwitchingProtocols = 101,

        [Display(Name = "Processing")]
        [Description("102 Processing")]
        Processing = 102,

        [Display(Name = "OK")]
        [Description("200 OK")]
        OK = 200,

        [Display(Name = "Created")]
        [Description("201 Created")]
        Created = 201,

        [Display(Name = "Accepted")]
        [Description("202 Accepted")]
        Accepted = 202,

        [Display(Name = "Non-authoritative Information")]
        [Description("203 Non-authoritative Information")]
        NonAuthoritativeInformation = 203,

        [Display(Name = "No Content")]
        [Description("204 No Content")]
        NoContent = 204,

        [Display(Name = "Reset Content")]
        [Description("205 Reset Content")]
        ResetContent = 205,

        [Display(Name = "Partial Content")]
        [Description("206 Partial Content")]
        PartialContent = 206,

        [Display(Name = "Multi-Status")]
        [Description("207 Multi-Status")]
        MultiStatus = 207,

        [Display(Name = "Already Reported")]
        [Description("208 Already Reported")]
        AlreadyReported = 208,

        [Display(Name = "IM Used")]
        [Description("226 IM Used")]
        IMUsed = 226,

        [Display(Name = "Multiple Choices")]
        [Description("300 Multiple Choices")]
        MultipleChoices = 300,

        [Display(Name = "Moved Permanently")]
        [Description("301 Moved Permanently")]
        MovedPermanently = 301,

        [Display(Name = "Found")]
        [Description("302 Found")]
        Found = 302,

        [Display(Name = "See Other")]
        [Description("303 See Other")]
        SeeOther = 303,

        [Display(Name = "Not Modified")]
        [Description("304 Not Modified")]
        NotModified = 304,

        [Display(Name = "Use Proxy")]
        [Description("305 Use Proxy")]
        UseProxy = 305,

        [Display(Name = "Temporary Redirect")]
        [Description("307 Temporary Redirect")]
        TemporaryRedirect = 307,

        [Display(Name = "Permanent Redirect")]
        [Description("308 Permanent Redirect")]
        PermanentRedirect = 308,

        [Display(Name = "Bad Request")]
        [Description("400 Bad Request")]
        BadRequest = 400,

        [Display(Name = "Unauthorized")]
        [Description("401 Unauthorized")]
        Unauthorized = 401,

        [Display(Name = "Payment Required")]
        [Description("402 Payment Required")]
        PaymentRequired = 402,

        [Display(Name = "Forbidden")]
        [Description("403 Forbidden")]
        Forbidden = 403,

        [Display(Name = "Not Found")]
        [Description("404 Not Found")]
        NotFound = 404,

        [Display(Name = "Method Not Allowed")]
        [Description("405 Method Not Allowed")]
        MethodNotAllowed = 405,

        [Display(Name = "Not Acceptable")]
        [Description("406 Not Acceptable")]
        NotAcceptable = 406,

        [Display(Name = "Proxy Authentication Required")]
        [Description("407 Proxy Authentication Required")]
        ProxyAuthenticationRequired = 407,

        [Display(Name = "Request Timeout")]
        [Description("408 Request Timeout")]
        RequestTimeout = 408,

        [Display(Name = "Conflict")]
        [Description("409 Conflict")]
        Conflict = 409,

        [Display(Name = "Gone")]
        [Description("410 Gone")]
        Gone = 410,

        [Display(Name = "Length Required")]
        [Description("411 Length Required")]
        LengthRequired = 411,

        [Display(Name = "Precondition Failed")]
        [Description("412 Precondition Failed")]
        PreconditionFailed = 412,

        [Display(Name = "Payload Too Large")]
        [Description("413 Payload Too Large")]
        PayloadTooLarge = 413,

        [Display(Name = "Request-URI Too Long")]
        [Description("414 Request-URI Too Long")]
        RequestUriTooLong = 414,

        [Display(Name = "Unsupported Media Type")]
        [Description("415 Unsupported Media Type")]
        UnsupportedMediaType = 415,

        [Display(Name = "Requested Range Not Satisfiable")]
        [Description("416 Requested Range Not Satisfiable")]
        RequestedRangeNotSatisfiable = 416,

        [Display(Name = "Expectation Failed")]
        [Description("417 Expectation Failed")]
        ExpectationFailed = 417,

        [Display(Name = "I'm a teapot")]
        [Description("418 I'm a teapot")]
        ImATeapot = 418,

        [Display(Name = "Misdirected Request")]
        [Description("421 Misdirected Request")]
        MisdirectedRequest = 421,

        [Display(Name = "Unprocessable Entity")]
        [Description("422 Unprocessable Entity")]
        UnprocessableEntity = 422,

        [Display(Name = "Locked")]
        [Description("423 Locked")]
        Locked = 423,

        [Display(Name = "Failed Dependency")]
        [Description("424 Failed Dependency")]
        FailedDependency = 424,

        [Display(Name = "Upgrade Required")]
        [Description("426 Upgrade Required")]
        UpgradeRequired = 426,

        [Display(Name = "Precondition Required")]
        [Description("428 Precondition Required")]
        PreconditionRequired = 428,

        [Display(Name = "Too Many Requests")]
        [Description("429 Too Many Requests")]
        TooManyRequests = 429,

        [Display(Name = "Request Header Fields Too Large")]
        [Description("431 Request Header Fields Too Large")]
        RequestHeaderFieldsTooLarge = 431,

        [Display(Name = "Connection Closed Without Response")]
        [Description("444 Connection Closed Without Response")]
        ConnectionClosedWithoutResponse = 444,

        [Display(Name = "Unavailable For Legal Reasons")]
        [Description("451 Unavailable For Legal Reasons")]
        UnavailableForLegalReasons = 451,

        [Display(Name = "Client Closed Request")]
        [Description("499 Client Closed Request")]
        ClientClosedRequest = 499,

        [Display(Name = "Internal Server Error")]
        [Description("500 Internal Server Error")]
        InternalServerError = 500,

        [Display(Name = "Not Implemented")]
        [Description("501 Not Implemented")]
        NotImplemented = 501,

        [Display(Name = "Bad Gateway")]
        [Description("502 Bad Gateway")]
        BadGateway = 502,

        [Display(Name = "Service Unavailable")]
        [Description("503 Service Unavailable")]
        ServiceUnavailable = 503,

        [Display(Name = "Gateway Timeout")]
        [Description("504 Gateway Timeout")]
        GatewayTimeout = 504,

        [Display(Name = "HTTP Version Not Supported")]
        [Description("505 HTTP Version Not Supported")]
        HttpVersionNotSupported = 505,

        [Display(Name = "Variant Also Negotiates")]
        [Description("506 Variant Also Negotiates")]
        VariantAlsoNegotiates = 506,

        [Display(Name = "Insufficient Storage")]
        [Description("507 Insufficient Storage")]
        InsufficientStorage = 507,

        [Display(Name = "Loop Detected")]
        [Description("508 Loop Detected")]
        LoopDetected = 508,

        [Display(Name = "Not Extended")]
        [Description("510 Not Extended")]
        NotExtended = 510,

        [Display(Name = "Network Authentication Required")]
        [Description("511 Network Authentication Required")]
        NetworkAuthenticationRequired = 511,

        [Display(Name = "Network Connection Timeout Error")]
        [Description("599 Network Connection Timeout Error")]
        NetworkConnectionTimeoutError = 599

    }
}
