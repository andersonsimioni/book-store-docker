using System.Data.Entity;
using System.Linq;

using Server.DataLayer.Repositories.BookStore.Models;

namespace Server.DataLayer.Extensions.BookStore;

public static class BookExtensions
{

    public static IEnumerable<Book> GetAll(this BookStoreContext context, int page = -1, int pageCount = -1)
    {
        return context.Books.AsNoTracking().Pagination(page, pageCount).ToList();
    }

    // GetBookById
    /// <summary>
    /// Gets a book from the BookStoreContext by its id
    /// </summary>
    /// <param name="context">The BookStoreContext to search in</param>
    /// <param name="id">The id of the book to search for</param>
    /// <returns>A list of books with the specified id</returns>
    public static IEnumerable<Book> GetBookById(this BookStoreContext context, int id)
    {
        return context.Books.AsNoTracking().Where(b=>b.BookId==id).Take(1).ToList();
    }

    // GetBookByAuthor
    /// <summary>
    /// Gets a book from the BookStoreContext by its author's name
    /// </summary>
    /// <param name="context">The BookStoreContext to search in</param>
    /// <param name="author">The author's name of the book to search for</param>
    /// <param name="page">The page number of the results to return (optional)</param>
    /// <param name="pageCount">The number of results per page (optional)</param>
    /// <returns>A list of books with the specified author's name</returns>
    public static IEnumerable<Book> GetBookByAuthor(this BookStoreContext context, string author, int page = -1, int pageCount = -1)
    {
        var nameToFind = author.ToLower().Replace(" ", "").Replace(".","");
        var query = context.Books.AsNoTracking().Where(b => string.Concat(b.FirstName, b.LastName).ToLower().Replace(" ", "").Replace(".","").Contains(nameToFind)); 
        return query.Pagination<Book>(page, pageCount).ToList();
    }

    // GetBookByTitle    
    /// <summary>
    /// Gets a book from the BookStoreContext by its title 
    /// </summary>
    /// <param name="context">The BookStoreContext to search in</param>
    /// <param name="title">The title of the book to search for</param>
    /// <param name="page">The page number of the results to return (optional)</param>
    /// <param name="pageCount">The number of results per page (optional)</param> 
    /// <returns>A list of books with the specified title</returns> 
    public static IEnumerable<Book> GetBookByTitle(this BookStoreContext context, string title, int page = -1, int pageCount = -1) 
    { 
        var nameToFind = title.ToLower().Replace(" ", "").Replace(".",""); 
        var query =  context.Books.AsNoTracking().Where(b => b.Title.ToLower().Replace(" ", "").Replace(".","").Contains(nameToFind)); 
        return query.Pagination<Book>(page, pageCount).ToList(); 
    }

    // GetBookByISBN
    /// <summary>
    /// Gets a book from the BookStoreContext by ISBN
    /// </summary>
    /// <param name="context">The BookStoreContext to search</param>
    /// <param name="isbn">The ISBN of the book to search for</param>
    /// <returns>A list of books with the specified ISBN</returns>
    public static IEnumerable<Book> GetBookByISBN(this BookStoreContext context, string isbn)
    {
        return context.Books.AsNoTracking().Where(b=>b.Isbn==isbn.ToString()).Take(1).ToList();
    }

    // GetBookByCategory
    /// <summary>
    /// Gets a list of books from the BookStoreContext by category
    /// </summary>
    /// <param name="context">The BookStoreContext to search</param>
    /// <param name="category">The category of the books to search for</param>
    /// <param name="page">The page number of the results to return (optional)</param>
    /// <param name="pageCount">The number of results per page (optional)</param>
    /// <returns>A list of books with the specified category</returns>
    public static IEnumerable<Book> GetBookByCategory(this BookStoreContext context, string category, int page = -1, int pageCount = -1)
    {
        var nameToFind = category.ToLower().Replace(" ", "").Replace(".","");
        var query = context.Books.AsNoTracking().Where(b=>b.Category.ToLower().Replace(" ", "").Replace(".","").Contains(nameToFind));
        return query.Pagination<Book>(page, pageCount).ToList();
    }

    // GetBookByType    
    /// <summary>
    /// Gets a list of books from the BookStoreContext by type 
    /// </summary>
    /// <param name="context">The BookStoreContext to search</param>
    /// <param name="type">The type of the books to search for</param> 
    /// <param name="page">The page number of the results to return (optional)</param> 
    /// <param name="pageCount">The number of results per page (optional)</param> 
    /// <returns>A list of books with the specified type</returns> 
    public static IEnumerable<Book> GetBookByType(this BookStoreContext context, string type, int page = -1, int pageCount = -1) 
    { 
        var nameToFind = type.ToLower().Replace(" ", "").Replace(".",""); 
        var query = context.Books.AsNoTracking().Where(b=>b.Type.ToLower().Replace(" ", "").Replace(".","").Contains(nameToFind)); 
        return query.Pagination<Book>(page, pageCount).ToList(); 
    }

    /// <summary>
    /// Gets a list of distinct categories from the BookStoreContext
    /// </summary>
    /// <param name="context">The BookStoreContext to query</param>
    /// <returns>A list of distinct categories</returns>
    public static IEnumerable<string> GetCategoriesList(this BookStoreContext context){
        return context.Books.Select(b=>b.Category).Distinct().ToList();
    }

    /// <summary>
    /// Gets a list of distinct authors from the BookStoreContext
    /// </summary>
    /// <param name="context">The BookStoreContext to query</param>
    /// <returns>A list of distinct authors</returns>
    public static IEnumerable<string> GetAuthorsList(this BookStoreContext context){
        return context.Books.Select(b=>string.Concat(b.FirstName, " ", b.LastName)).Distinct().ToList();
    }

}