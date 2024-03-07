document.getElementById("add-property").addEventListener("click", function () {
    let container = document.getElementById("property-list");
    let index = container.getElementsByClassName("property-entry").length;
    let newDiv = document.createElement("div");
    newDiv.className = "property-entry";
    newDiv.id = "property" + (index + 1);
    let personEntry = container.closest('.person');

    if (!areAllFieldsValid(personEntry)) {
        return;
    }

    let propertyStatusOptionsHtml = propertyStatusList.map(option =>
        `<option value="${option.Value}">${option.Text}</option>`
    ).join('');

    newDiv.innerHTML =
        '<div class="form-group">' +
        '<label> Īpašuma nosaukums</label >' +
        '<input type="text" class="form-control" name="LandProperties[' + index + '].Name" class="form-control" required />' +
        '</div >' +
        '<div class="form-group">' +
        '<label> Kadastra numurs</label >' +
        '<input type="number" class="form-control" name="LandProperties[' + index + '].CadastralMark" class="form-control" required />' +
        '</div >' +
        '<div class="form-group">' +
        '<label>Status</label>' +
        '<select class="form-control" name="LandProperties[' + index + '].Status">' +
        propertyStatusOptionsHtml +
        '</select>' +
        '</div>' +
        '<button type="button" class="btn btn-danger btn-sm" onclick="removeEntry(this)">Remove</button>' +
        '<button type="button" class="btn btn-secondary" onclick="addPlot(this)">Pievienot zemes gabalu</button>' +
        '<div class="list plot-list"></div>';

    container.appendChild(newDiv);
});

function addPlot(buttonElement) {
    let propertyEntry = buttonElement.closest('.property-entry');

    if (!areAllFieldsValid(propertyEntry)) {
        return;
    }

    let container = document.getElementById("property-list");
    let propertyEntries = container.getElementsByClassName("property-entry");
    let propertyIndex = Array.from(propertyEntries).indexOf(propertyEntry);

    let plotsContainer = buttonElement.parentElement.querySelector(".plot-list");
    let index = plotsContainer.getElementsByClassName("plot-entry").length;
    let newPlotDiv = document.createElement("div");
    newPlotDiv.className = "plot-entry";
    newPlotDiv.id = "plot" + (index + 1);
    let today = new Date().toISOString().split('T')[0];

    newPlotDiv.innerHTML =
        '<div class="form-group">' +
        '<label>Kadastra numurs</label>' +
        '<input  type=""  name="LandProperties[' + propertyIndex + '].Plots[' + index + '].CadastralMark" class="form-control"  required />' +
        '</div>' +
        '<div class="form-group">' +
        '<label>Kopplatība hektāros</label>' +
        '<input type="number" step="0.01" min="0" name="LandProperties[' + propertyIndex + '].Plots[' + index + '].TotalAreaInHectares" class="form-control" required />' +
        '</div>' +
        '<div class="form-group">' +
        '<label>Uzmērīšanas datums</label>' +
        '<input name="LandProperties[' + propertyIndex + '].Plots[' + index + '].DateOfSurvey" type="date" class="form-control date-input" max="' + today + '" required />' +
        '</div>' +
        '<button type="button" class="btn btn-danger btn-sm" onclick="removeEntry(this)">Remove</button>' +

        '<button type="button" class="btn btn-secondary" onclick="addLandType(this)">Pievienot zemes lietojumu</button>' +
        '<div class="list land-type-list"></div>';

    plotsContainer.appendChild(newPlotDiv);
}

function addLandType(buttonElement) {
    let landTypesContainer = buttonElement.nextElementSibling;
    let propertyEntry = buttonElement.closest('.property-entry');
    let propertyIndex = Array.from(propertyEntry.parentNode.children).indexOf(propertyEntry);
    let plotEntry = buttonElement.closest('.plot-entry');
    let plotIndex = Array.from(plotEntry.parentNode.children).indexOf(plotEntry);

    if (!areAllFieldsValid(plotEntry)) {
        return;
    }

    let index = landTypesContainer.getElementsByClassName("type-entry").length;
    let newLandTypeDiv = document.createElement("div");
    newLandTypeDiv.className = "type-entry";

    let landTypeOptionsHtml = landTypeList.map(option =>
        `<option value="${option.Value}">${option.Text}</option>`
    ).join('');

    newLandTypeDiv.innerHTML =
        '<div class="form-group">' +
        '<label>Zemes lietojums</label>' +
        '<select class="form-control" name="LandProperties[' + propertyIndex + '].Plots[' + plotIndex + '].LandTypes[' + index + '].Type">' +
        landTypeOptionsHtml +
        '</select>' +
        '</div>' +
        '<div class="form-group">' +
        '<label>Platība hektāros</label>' +
        '<input type="number" step="0.01" min="0" name="LandProperties[' + propertyIndex + '].Plots[' + plotIndex + '].LandTypes[' + index + '].AreaInHectares" class="form-control" required />' +
        '</div>' +
        '<button type="button" class="btn btn-danger btn-sm" onclick="removeEntry(this)">Remove</button>';

    landTypesContainer.appendChild(newLandTypeDiv);
}

function areAllFieldsValid(entry) {
    let isValid = true;

    const inputs = entry.querySelectorAll('input, select');

    for (let input of inputs) {
        if (!input.value.trim()) {
            alert('Visiem laukiem jābūt aizpidlītiem.');
            isValid = false;
            break;
        }
        else if (input.type === 'date') {
            if (!input.value) {
                alert('Lūdzu izvēlies datumu.');
                isValid = false;
                break;
            }
        }
    }

    return isValid;
}

function removeEntry(element) {
    element.parentElement.remove();
}