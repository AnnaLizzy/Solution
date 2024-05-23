namespace WebApplicationAPI.Models.Enum
{
    /// <summary>
    /// Trạng thái của một đối tượng
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// Tạm lưu
        /// </summary>
        TAM_LUU = 0,
        /// <summary>
        /// Đang chờ duyệt
        /// </summary>
        CHO_KY = 1,
        /// <summary>
        /// Đã duyệt
        /// </summary>
        DA_KY = 2,
        /// <summary>
        /// Trả lại 
        /// </summary>
        TRA_LAI =3,
        /// <summary>
        /// Giá trị mặc định, không xác định
        /// </summary>
        Unknown = 999
    }
}
