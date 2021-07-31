using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyNotes.Data
{
    public class NoteService
    {
        #region Property
        private readonly MyNotesDbContext _appDBContext;
        #endregion

        #region Constructor
        public NoteService(MyNotesDbContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        #endregion

        #region Get List of Employees
        public async Task<List<Note>> GetAllNotesAsync()
        {
            return await _appDBContext.Notes.ToListAsync();
        }
        #endregion

        #region Insert Note
        public async Task<bool> InsertNoteAsync(Note note)
        {
            await _appDBContext.Notes.AddAsync(note);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Get Note by Id
        public async Task<Note> GetNoteAsync(int Id)
        {
            Note employee = await _appDBContext.Notes.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return employee;
        }
        #endregion

        #region Update Note
        public async Task<bool> UpdateNoteAsync(Note employee)
        {
            _appDBContext.Notes.Update(employee);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Delete Note
        public async Task<bool> DeleteNoteAsync(Note employee)
        {
            _appDBContext.Remove(employee);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion
    }
}
