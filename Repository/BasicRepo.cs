using Microsoft.EntityFrameworkCore;
using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
	public class BasicRepo<T> : IBasicRepo<T> where T : class
	{
		private readonly CharityDbContex _dbContext;

		public BasicRepo(CharityDbContex dbContext)
		{
			_dbContext = dbContext;
		}


		public IQueryable<T> GetAll()
		{
			return  _dbContext.Set<T>();
		}

		public  void Add(T entity)
		{
			_dbContext.Set<T>().Add(entity);
			
		}

		public  void Delete(T entity)
		{
			 _dbContext.Set<T>().Remove(entity);
			
		}

		public  void Update(T entity)
		{
			_dbContext.Set<T>().Update(entity);
			
		}


		public async Task SaveChangeAsync()
		{
			await _dbContext.SaveChangesAsync();
		}

		
	}
}
