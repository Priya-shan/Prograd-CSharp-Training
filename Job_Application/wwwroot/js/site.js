﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function onDelete(id) {
    console.log("in js");
    if (confirm("Are you sure you want to delete Job ID = " + id + "?")) {
        location.replace("Admin/Index?opnMode=delete&JobId=" + id);
    }
}