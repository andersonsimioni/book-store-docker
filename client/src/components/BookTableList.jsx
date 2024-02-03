/* eslint-disable import/no-anonymous-default-export */

import './BookTableList.css'
import {React, Fragment, useState, useEffect } from "react";

export default props => {
    const [currentPage, setCurrentPage] = useState(1)
    const [totalPages, setTotalPages] = useState()
    const [listPagination, setListPagination] = useState([])

    useEffect(() => {
        setTotalPages(Math.ceil(props.books?.length / 5))
    }, [totalPages, props.books])

    useEffect(() => {
        var listAux = []
        for(var i=0; i<totalPages; i++){
            listAux.push(i+1)
        }
        setListPagination(listAux)
    }, [totalPages, listPagination])

    return (
        <Fragment>
            <table id="table-books">
                <thead>
                    <tr>
                        <th>Book Title</th>
                        <th>Author</th>
                        <th>Type</th>
                        <th>ISBN</th>
                        <th>Category</th>
                        <th>Available Copies</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        props.books === undefined || props.books.length === 0 ? 
                            false
                        :
                        props.books.slice((currentPage-1)*5, (currentPage-1)*5 + 5).map(book=>{
                            return (
                                <tr key={book.bookId}>
                                    <td>{book.title}</td>
                                    <td>{book.firstName} {book.lastName}</td>
                                    <td>{book.type}</td>
                                    <td>{book.isbn}</td>
                                    <td>{book.category}</td>
                                    <td>{book.totalCopies - book.copiesInUse} / {book.totalCopies}</td>
                                </tr>
                            )
                    })}
                </tbody>
            </table>
            
            <div>
                <button onClick={() => setCurrentPage(currentPage-1)} disabled={currentPage === 1}>{"<"}</button>
                {listPagination?.map((item) => {
                    return(
                        <button onClick={() => setCurrentPage(item)} className={`${currentPage === item ? 'active' : ''}`}>{item}</button>
                    )
                })}
                <button onClick={() => setCurrentPage(currentPage+1)} disabled={currentPage === totalPages}>{">"}</button>
            </div>

            {props.books === undefined || props.books.length === 0 ? 
                <div><p id="no-books-warning">No books found!</p></div> : 
                <div></div>}
        </Fragment>
    );
}