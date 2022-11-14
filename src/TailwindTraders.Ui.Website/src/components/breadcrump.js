import React from "react";
const Breadcrump = () => {
    let path = window.location.pathname.split("/")
    return(
        <div className="breadcrump">
            <p>
                {path.length > 0 ? <b>Home / </b> : null}
                {path.length > 1 && path[1] ? <b>{path[1] ? path[1] : 'Gaming & Accessories'} / </b> : null}
                {path.length > 2 && path[2] ? <span>{path[2] ? path[2] : 'Controllers'}</span> : null}
            </p>
        </div>
    );
}
export default Breadcrump;