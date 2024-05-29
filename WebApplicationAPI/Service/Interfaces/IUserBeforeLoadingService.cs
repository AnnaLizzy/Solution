namespace WebApplicationAPI.Service.Interfaces
{
    /// <summary>
    /// Get User
    /// </summary>
    public interface IUserBeforeLoadingService
    {
        /// <summary>
        /// get all User
        /// </summary>
        /// <returns></returns>
        Task<List<UserBeforeLodingDTO>> GetUserBeforeLoading();
        /// <summary>
        /// Get User by BGID
        /// </summary>
        /// <param name="bgid"></param>
        /// <returns></returns>
        Task<List<UserBeforeLodingDTO>> GetUserBeforeLoadingByBG(int bgid);
        /// <summary>
        /// Get User Before Loading By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserBeforeLodingDTO> GetUserBeforeLoadingById(int id);

    }
}
