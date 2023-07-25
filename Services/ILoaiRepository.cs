using My_web_API.Data;
using My_web_API.Models;
using System.Collections.Generic;

namespace My_web_API.Services
{
    public interface ILoaiRepository
    {
        List<LoaiVM> GetAll();
        LoaiVM GetById(int id);
        LoaiVM Add(LoaiVM loai);
        void Update(LoaiVM loai);
        void Delete(int id);

    }
}
