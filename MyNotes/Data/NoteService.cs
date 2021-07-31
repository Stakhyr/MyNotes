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
            Note note = await _appDBContext.Notes.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return note;
        }
        #endregion

        #region Update Note
        public async Task<bool> UpdateNoteAsync(Note note)
        {
            _appDBContext.Notes.Update(note);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Delete Note
        public async Task<bool> DeleteNoteAsync(Note note)
        {
            _appDBContext.Remove(note);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Seach Note
        public async Task<List<Note>> SeachTermsAsync(string searchItem)
        {
            return await _appDBContext.Notes.Where(s => s.Title.ToLower().Contains(searchItem.ToLower())
            || s.Text.ToLower().Contains(searchItem.ToLower())).ToListAsync();
        }
        #endregion
    }
}
