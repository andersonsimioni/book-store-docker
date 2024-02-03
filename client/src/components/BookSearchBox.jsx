/* eslint-disable import/no-anonymous-default-export */
import {React, useState } from "react";

export default props => {
    const [val, setVal] = useState();
    const [prop, setProp] = useState('Title');

    function handleChangeVal(e){
        setVal(e.target.value);
    }

    function handleChangeProp(e){
        setProp(e.target.value);
    }

    function handleFindBooks(){
        props.findBooks(prop, val);
    }

    return (
        <div>
            <input onChange={e=>handleChangeVal(e)} id="txt-search-by-val" list="txt-search-by-val-lst"  type="text" placeholder="Search book by.."/>
            <select onChange={e=>handleChangeProp(e)} id="select-search-by-prop" style={{height: "22px"}}>
                <option>Title</option>
                <option>Author</option>
                <option>Category</option>
                <option>Type</option>
                <option>ISBN</option>
            </select>
            <button onClick={handleFindBooks} id="search-btn">Search</button>
        </div>
    )
}