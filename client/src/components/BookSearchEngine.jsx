/* eslint-disable import/no-anonymous-default-export */
import {React, Fragment, useState, useEffect} from "react";
import BookSearchBox from "./BookSearchBox";
import BookTableList from "./BookTableList";
import { getBookByAuthor, getBookByCategory, getBookByISBN, getBookByTitle, getBookByType, getAll } from "../api/bookStoreApi";

export default props => {

    const [books, setBooks] = useState();

    const apiFunctionDict = {
        'author': v=>getBookByAuthor(v),
        'title': v=>getBookByTitle(v),
        'category': v=>getBookByCategory(v),
        'isbn': v=>getBookByISBN(v),
        'type': v=>getBookByType(v),
        'all': v=>getAll()
    };

    function findBooks(prop, val){
        let _prop = prop.toLowerCase();
        if(val === '' || val === undefined || val === null) _prop = 'all';
        apiFunctionDict[_prop](val).then(r => setBooks(r));
    }

    useEffect(()=>{
        findBooks('','');
    }, []);

    return (
        <Fragment>
            <BookSearchBox findBooks={findBooks}></BookSearchBox>
            <BookTableList books={books}></BookTableList>
        </Fragment>
    )
}