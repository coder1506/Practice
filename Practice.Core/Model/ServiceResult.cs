using Microsoft.AspNetCore.Mvc;

namespace Practice.Core.Model
{
    public class ServiceResult
    {
        /// <summary>
        /// Thành công hoặc thất bại
        /// </summary>
        public bool Success { get; set; } = true;
        /// <summary>
        /// Dữ liệu trả về
        /// </summary>
        public object? Data { get; set; }
        /// <summary>
        /// Mã lỗi
        /// </summary>
        public int? ErrorCode { get; set; }
        /// <summary>
        /// Thông báo lỗi cho người dùng
        /// </summary>
        public string? UserMsg { get; set; }
        /// <summary>
        /// Thông báo lỗi cho kỹ thuật
        /// </summary>
        public string? DevMsg { get; set; }
        /// <summary>
        /// Ngày server
        /// </summary>
        public DateTime ServerTime { get; set; } = DateTime.Now;

        public ServiceResult(bool success, object? data, int? errorCode, string? userMsg, string? devMsg, DateTime serverTime)
        {
            Success = success;
            Data = data;
            ErrorCode = errorCode;
            UserMsg = userMsg;
            DevMsg = devMsg;
            ServerTime = serverTime;
        }

        public ServiceResult()
        {
        }
    }
}
