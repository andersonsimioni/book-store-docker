/* eslint-disable use-isnan */
const apiUrl = process.env.NODE_ENV === 'development' ? 'https://localhost:7201' : 'http://localhost:8000';

/**
 * Get a list of book categories from the API
 * @returns {Promise<Object>} A promise that resolves to an object containing the book categories
 */
export async function getCategories(){
    try {
        const response = await fetch(`${apiUrl}/Books/GetCategories`);
        const data = await response.json();
        return data;
    } catch (error) {
        console.error(error);
    }
}

/**
 * Get a list of book authors from the API
 * @returns {Promise<Object>} A promise that resolves to an object containing the book authors
 */
export async function getAuthors(){
    try {
        const response = await fetch(`${apiUrl}/Books/GetAuthors`);
        const data = await response.json();
        return data;
    } catch (error) {
        console.error(error);
    }
}


/** 
 * Get a list of books by author from the API 
 * @param {string} author The author of the books to be retrieved 
 * @returns {Promise<Object>} A promise that resolves to an object containing the books by the specified author 
 */ 
export async function getBookByAuthor(author){ 
    try { 
        if(author=='') return []; 
        const response = await fetch(`${apiUrl}/Books/GetByAuthor?author=${author}`); 
        const data = await response.json(); 
        return data; 
    } catch (error) { 
        console.error(error); 
    } 
} 

 /** 
 * Get a list of books by category from the API 
 * @param {string} category The category of the books to be retrieved 
 * @returns {Promise<Object>} A promise that resolves to an object containing the books in the specified category 
 */
export async function getBookByCategory(category){  
    try {  
        if(category=='') return [];  
        const response = await fetch(`${apiUrl}/Books/GetByCategory?category=${category}`);  
        const data = await response.json();  
        return data; 
    } 
    catch (error) { 
        console.error(error); 
    } 
}

 /**  
  * * Get a list of books by ISBN from the API   * 
  * @param {string} isbn The ISBN of the books to be retrieved   
  * @returns {Promise<Object>} A promise that resolves to an object containing the books with the specified ISBN   
  */ 
export async function getBookByISBN(isbn){   
    try {   
        if(isbn=='') return [];   
        const response = await fetch(`${apiUrl}/Books/GetByIsbn?isbn=${isbn}`);   
        const data = await response.json();   
        return data;   
    } catch (error) {   
        return [];   
    } 
}

 /**   
  * Get a list of books by title from the API   
  * @param {string} title The title of the books to be retrieved   
  * @returns {Promise<Object>} A promise that resolves to an object containing the books with the specified title   
  */ 
export async function getBookByTitle(title){   
    try {   
        if(title == '') return [];   
        const response = await fetch(`${apiUrl}/Books/GetByTitle?title=${title}`);   
        const data = await response.json();   
        return data;   
    } catch (error) {   
        console.error(error);   
    } 
}

 /**   
  * Get a list of books by type from the API   
  * @param {string} type The type of the books to be retrieved   
  * @returns {Promise<Object>} A promise that resolves to an object containing the books with the specified type   
  */ 
export async function getBookByType(type){   
    try {   
        if(type == '') return [];   
        const response = await fetch(`${apiUrl}/Books/GetByType?type=${type}`);   
        const data = await response.json();   return data;   
    } catch (error) {   
        console.error(error);   
    } 
}


export async function getAll(){   
    try {   
        const response = await fetch(`${apiUrl}/Books/GetAll`);   
        const data = await response.json();   return data;   
    } catch (error) {   
        console.error(error);   
    } 
}