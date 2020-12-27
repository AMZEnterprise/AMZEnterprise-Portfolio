var Panel = (function () {

    //Render Table Buttons
    function renderButtons(editUrl, detailsUrl, deleteUrl, id) {

        var result = "";

        if (editUrl !== undefined) {
            var linkEdit = `<a href="${editUrl}/-1" class="btn btn-primary" title="edit"><i class="fa fa-pencil"></i></a>`;
            linkEdit = linkEdit.replace("-1", id);

            result += linkEdit;
        }

        if (detailsUrl !== undefined) {
            var linkDetails = `<a href="${detailsUrl}/-1" class="btn btn-warning" title="details"><i class="fa fa-list"></i></a>`;
            linkDetails = linkDetails.replace("-1", id);

            result += " | " + linkDetails;
        }

        if (deleteUrl !== undefined) {
            var linkDelete = `<a href="${deleteUrl}/-1" class="btn btn-danger" title="delete"><i class="fa fa-trash"></i></a>`;
            linkDelete = linkDelete.replace("-1", id);

            result += " | " + linkDelete;
        }

        return result;
    }

    function boolToText(val) {
        if (val === true) {
            return "بله";
        }
        return "خیر";
    }

    function reduceTextToSmallerWidth(text, charsCount) {
        return (text.length > charsCount) ? text.substr(0, charsCount - 1) + '&hellip;' : text;
    }


    var loadContacts = function contacts(apiUrl, editUrl) {
        $("#jq-table").DataTable({
            responsive: true,
            // Design Assets
            stateSave: true,
            autoWidth: true,
            // ServerSide Setups
            processing: true,
            serverSide: true,
            // Paging Setups
            paging: true,
            // Searching Setups
            searching: { regex: true },
            // Ajax Filter
            ajax: {
                url: apiUrl,
                type: "POST",
                contentType: "application/json",
                dataType: "json",
                data: function (d) {
                    return JSON.stringify(d);
                }
            },
            // Columns Setups
            columns: [
                { data: "fullName" },
                { data: "email" },
                { data: "subject" },
                { data: "message" },
                { data: "ip" },
                { data: "createDate" },
                {
                    mRender: function (data, type, row) {
                        return renderButtons(editUrl, undefined, undefined, row.id);
                    }
                }
            ],
            // Column Definitions
            columnDefs: [
                { targets: "no-sort", orderable: false },
                { targets: "no-search", searchable: false },
                {
                    targets: "trim",
                    render: function (data, type, full, meta) {
                        if (type === "display") {
                            data = strtrunc(data, 10);
                        }

                        return data;
                    }
                },
                { targets: "date-type", type: "date-eu" }
            ]
        });
    }

    var loadFavors = function favors(apiUrl, editUrl) {
        return $("#jq-table").DataTable({
            responsive: true,
            // Design Assets
            stateSave: true,
            autoWidth: true,
            // ServerSide Setups
            processing: true,
            serverSide: true,
            // Paging Setups
            paging: true,
            // Searching Setups
            searching: { regex: true },
            // Ajax Filter
            ajax: {
                url: apiUrl,
                type: "POST",
                contentType: "application/json",
                dataType: "json",
                data: function (d) {
                    return JSON.stringify(d);
                }
            },
            // Columns Setups
            columns: [
                { data: "title" },
                {
                    data: "description",
                    render: function (data, type, row) {
                        return reduceTextToSmallerWidth(row.description, 50);
                    }
                },
                {
                    mRender: function (data, type, row) {
                        return renderButtons(editUrl, undefined, undefined, row.id);
                    }
                }
            ],
            // Column Definitions
            columnDefs: [
                { targets: "no-sort", orderable: false },
                { targets: "no-search", searchable: false },
                {
                    targets: "trim",
                    render: function (data, type, full, meta) {
                        if (type === "display") {
                            data = strtrunc(data, 10);
                        }

                        return data;
                    }
                },
                { targets: "date-type", type: "date-eu" }
            ]
        });
    }


    var loadSkills = function skills(apiUrl, editUrl) {
        return $("#jq-table").DataTable({
            responsive: true,
            // Design Assets
            stateSave: true,
            autoWidth: true,
            // ServerSide Setups
            processing: true,
            serverSide: true,
            // Paging Setups
            paging: true,
            // Searching Setups
            searching: { regex: true },
            // Ajax Filter
            ajax: {
                url: apiUrl,
                type: "POST",
                contentType: "application/json",
                dataType: "json",
                data: function (d) {
                    return JSON.stringify(d);
                }
            },
            // Columns Setups
            columns: [
                { data: "title" },
                { data: "percent" },
                {
                    data: "skillType",
                    render: function (data, type, row) {
                        switch (row.skillType) {
                            case 1000:
                                return "ProcessBar";
                            case 2000:
                                return "Stars";
                        }
                    }
                },
                {
                    mRender: function (data, type, row) {
                        return renderButtons(editUrl, undefined, undefined, row.id);
                    }
                }
            ],
            // Column Definitions
            columnDefs: [
                { targets: "no-sort", orderable: false },
                { targets: "no-search", searchable: false },
                {
                    targets: "trim",
                    render: function (data, type, full, meta) {
                        if (type === "display") {
                            data = strtrunc(data, 10);
                        }

                        return data;
                    }
                },
                { targets: "date-type", type: "date-eu" }
            ]
        });
    }


    var loadPortfolios = function portfolios(apiUrl, editUrl) {
        return $("#jq-table").DataTable({
            responsive: true,
            // Design Assets
            stateSave: true,
            autoWidth: true,
            // ServerSide Setups
            processing: true,
            serverSide: true,
            // Paging Setups
            paging: true,
            // Searching Setups
            searching: { regex: true },
            // Ajax Filter
            ajax: {
                url: apiUrl,
                type: "POST",
                contentType: "application/json",
                dataType: "json",
                data: function (d) {
                    return JSON.stringify(d);
                }
            },
            // Columns Setups
            columns: [
                { data: "title" },
                { data: "shortDescription" },
                { data: "employerFullName" },
                { data: "technologies" },
                {
                    data: "portfolioType",
                    render: function (data, type, row) {
                        switch (row.portfolioType) {
                            case 1000:
                                return "Website";
                            case 2000:
                                return "Application";
                            case 3000:
                                return "Seo";
                            case 4000:
                                return "Other";
                        }
                    }
                },
                {
                    mRender: function (data, type, row) {
                        return renderButtons(editUrl, undefined, undefined, row.id);
                    }
                }
            ],
            // Column Definitions
            columnDefs: [
                { targets: "no-sort", orderable: false },
                { targets: "no-search", searchable: false },
                {
                    targets: "trim",
                    render: function (data, type, full, meta) {
                        if (type === "display") {
                            data = strtrunc(data, 10);
                        }

                        return data;
                    }
                },
                { targets: "date-type", type: "date-eu" }
            ]
        });
    }


    var loadResumes = function resumes(apiUrl, editUrl) {
        return $("#jq-table").DataTable({
            responsive: true,
            // Design Assets
            stateSave: true,
            autoWidth: true,
            // ServerSide Setups
            processing: true,
            serverSide: true,
            // Paging Setups
            paging: true,
            // Searching Setups
            searching: { regex: true },
            // Ajax Filter
            ajax: {
                url: apiUrl,
                type: "POST",
                contentType: "application/json",
                dataType: "json",
                data: function (d) {
                    return JSON.stringify(d);
                }
            },
            // Columns Setups
            columns: [
                { data: "title" },
                { data: "description" },
                {
                    data: "resumeType",
                    render: function (data, type, row) {
                        switch (row.resumeType) {
                            case 1000:
                                return "Education";
                            case 2000:
                                return "Experience";
                        }
                    }
                },
                { data: "date" },
                {
                    mRender: function (data, type, row) {
                        return renderButtons(editUrl, undefined, undefined, row.id);
                    }
                }
            ],
            // Column Definitions
            columnDefs: [
                { targets: "no-sort", orderable: false },
                { targets: "no-search", searchable: false },
                {
                    targets: "trim",
                    render: function (data, type, full, meta) {
                        if (type === "display") {
                            data = strtrunc(data, 10);
                        }

                        return data;
                    }
                },
                { targets: "date-type", type: "date-eu" }
            ]
        });
    }

    var loadSocialMedias = function socialMedias(apiUrl, editUrl) {
        return $("#jq-table").DataTable({
            responsive: true,
            // Design Assets
            stateSave: true,
            autoWidth: true,
            // ServerSide Setups
            processing: true,
            serverSide: true,
            // Paging Setups
            paging: true,
            // Searching Setups
            searching: { regex: true },
            // Ajax Filter
            ajax: {
                url: apiUrl,
                type: "POST",
                contentType: "application/json",
                dataType: "json",
                data: function (d) {
                    return JSON.stringify(d);
                }
            },
            // Columns Setups
            columns: [
                { data: "title" },
                { data: "url" },
                { data: "iconCss" },
                {
                    mRender: function (data, type, row) {
                        return renderButtons(editUrl, undefined, undefined, row.id);
                    }
                }
            ],
            // Column Definitions
            columnDefs: [
                { targets: "no-sort", orderable: false },
                { targets: "no-search", searchable: false },
                {
                    targets: "trim",
                    render: function (data, type, full, meta) {
                        if (type === "display") {
                            data = strtrunc(data, 10);
                        }

                        return data;
                    }
                },
                { targets: "date-type", type: "date-eu" }
            ]
        });
    }

    //===================================
    //              Editor
    //===================================
    var initialEditor = function bindEditor(elementId) {
        let element;

        if (elementId === undefined) {
            element = $("#txtContent");
        } else {
            element = $(elementId);
            console.log(elementId);
        }

        element.ckeditor({
            extraPlugins: 'wordcount'
        });
    }

    var initialEditorReadOnly = function bindEditorReadOnly(elementId) {
        let element;

        if (elementId === undefined) {
            element = $("#txtContent");
        } else {
            element = $(elementId);
        }

        element.ckeditor({
            readOnly: true,
            extraPlugins: 'wordcount'
        });
    }

    //===================================
    //              Files Preview
    //===================================
    var initialFilesPreview = function filePreview() {

        window.onload = function () {
            //Check File API support
            if (window.File && window.FileList && window.FileReader) {
                var filesInput = document.getElementById("input-files-hidden");
                filesInput.addEventListener("change",
                    function (event) {
                        var files = event.target.files; //FileList object
                        var output = document.getElementById("files-preview");
                        output.innerHTML = "";
                        for (var i = 0; i < files.length; i++) {
                            var file = files[i];
                            //Only pics
                            if (!file.type.match("image"))
                                continue;
                            var picReader = new FileReader();
                            picReader.addEventListener("load",
                                function (event) {
                                    var picFile = event.target;
                                    var img = document.createElement("IMG");
                                    img.setAttribute("class", "thumbnail");
                                    img.setAttribute("src", `${picFile.result}`);

                                    output.appendChild(img);
                                });
                            //Read the image
                            picReader.readAsDataURL(file);
                        }
                    });
            } else {
                console.log("Your browser does not support File API");
            }
        }
    }



    var getPortfolioFile = function portfolioFile(url, portfolioId) {
        $.ajax({
            url: url,
            dataType: "json",
            data: {
                id: portfolioId
            },
            success: function (data) {
                if (data !== null && data !== undefined) {
                    var output = document.getElementById("files-preview");
                    var img = document.createElement("IMG");
                    img.setAttribute("class", "thumbnail");
                    img.setAttribute("src", data);
                    output.appendChild(img);
                }
            }
        });
    }

    //Return Values(inner functions)
    return {

        LoadContacts: loadContacts,
        LoadFavors: loadFavors,
        LoadSkills: loadSkills,
        LoadPortfolios: loadPortfolios,
        LoadResumes: loadResumes,
        LoadSocialMedias: loadSocialMedias,

        InitialEditor: initialEditor,
        InitialEditorReadOnly: initialEditorReadOnly,
        InitialFilesPreview: initialFilesPreview,

        GetPortfolioFile: getPortfolioFile
    }

})();