﻿using ApiLibrary.ViewModels;

namespace ApiLibrary.Interfaces
{
    public interface IListLocationApiClient
    {
        //Lay dia diem cua database khac
        Task<List<ListLocationVM>> GetAllLocations();
        Task<ListLocationVM> GetLocationById(int id);
        //tao dia diem moi dua tren database tren
        Task<bool> CreateLocation(ListLocationVM location);
        Task<bool> DeleteLocation(int id);
        Task<bool> UpdateLocation(int id,ListLocationVM location);
    }
}
