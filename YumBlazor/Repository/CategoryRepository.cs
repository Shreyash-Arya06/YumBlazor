using Microsoft.EntityFrameworkCore;
using YumBlazor.Data;
using YumBlazor.Repository.IRepository;

namespace YumBlazor.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        //public Category Create(Category obj)
        //{
        //    //throw new NotImplementedException();
        //    _db.Category.Add(obj);
        //    _db.SaveChanges();
        //    return obj;
        //}
        //public Category Update(Category obj)
        //{
        //    var objFromDb = _db.Category.FirstOrDefault(u => u.Id == obj.Id);
        //    if (objFromDb is not null)
        //    {
        //        objFromDb.Name = obj.Name;
        //        _db.Category.Update(objFromDb);
        //        _db.SaveChanges();
        //        return objFromDb;
        //    }
        //    return new Category();
        //}
        //public bool Delete(int id)
        //{
        //    var obj = _db.Category.FirstOrDefault(u=>u.Id == id);
        //    if (obj != null)
        //    {
        //        _db.Category.Remove(obj);
        //        return _db.SaveChanges() > 0;
        //    }
        //    return false;
        //}
        //public Category Get(int id)
        //{
        //    var obj = _db.Category.FirstOrDefault(u => u.Id == id);
        //    if (obj == null)
        //    {
        //        return new Category();
        //    }
        //    return obj;
        //}
        //public IEnumerable<Category> GetAll()
        //{
        //    return _db.Category.ToList();
        //}

        public async Task<Category> CreateAsync(Category obj)
        {
            await _db.Category.AddAsync(obj);
            await _db.SaveChangesAsync();
            return obj;
        }
        public async Task<Category> UpdateAsync(Category obj)
        {
            var objFormDb = await _db.Category.FirstOrDefaultAsync(u => u.Id == obj.Id);
            if (objFormDb is not null)
            {
                objFormDb.Name = obj.Name;
                _db.Category.Update(objFormDb);
                await _db.SaveChangesAsync();
                return objFormDb;
            }
            return new Category();
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var obj = await _db.Category.FirstOrDefaultAsync(u => u.Id == id);
            if (obj is not null)
            {
                _db.Category.Remove(obj);
                return (await _db.SaveChangesAsync()) > 0;
            }
            return false;
        }
        public async Task<Category> GetAsync(int id)
        {
            var obj = await _db.Category.FirstOrDefaultAsync(u => u.Id == id);
            if (obj is null)
            {
                return new Category();
            }
            return obj;
        }
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _db.Category.ToListAsync();
        }
    }
}
