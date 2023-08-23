using ElTezam_Coded_WebApp.DomainModels;
using ElTezam_Coded_WebApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ElTezam_Coded_WebApp.Services
{
    public interface IDropDownService
    {
         Task<object> GetDropDown<T>(Expression<Func<T, object>> selector, Expression<Func<T, bool>>? filter) where T : class;
        Task<object> GetEnumDropDown<E>() where E : System.Enum;
    }
    public class DropDownService:IDropDownService
    {
        private readonly CodedContext context;
        public DropDownService(CodedContext context)
        {
            //context = new CodedContext();
            this.context = context;
        }
        public async Task<object> GetEnumDropDown<E>() where E : System.Enum
        {
            List<DropDownModel> collection = new();
            var values = System.Enum.GetValues(typeof(E));
            foreach (var value in values)
                collection.Add(new DropDownModel { Id= value.ToString() ,Value= value.ToString() });
            return collection;
        }
        public async Task<object> GetDropDown<T>(Expression<Func<T, object>> selector, Expression<Func<T, bool>>? filter) where T : class 
        {
            if (selector != null && filter != null)
                return await context.Set<T>().Where(filter).Select(selector).AsNoTracking().Distinct().ToListAsync();
            else if (selector != null)
                return await context.Set<T>().Select(selector).AsNoTracking().Distinct().ToListAsync();
            else if (filter != null)
                return await context.Set<T>().Where(filter).AsNoTracking().Distinct().ToListAsync();
            else
                return await context.Set<T>().AsNoTracking().Distinct().ToListAsync();
        }
    }
}
