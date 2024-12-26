$(() => {
    $("#submitButton").on('click', async function () {
        let price = parseFloat($("#answer1").val());  // Corrected selector for answer1
        let purpose = $("#answer2").val();  // Corrected selector for answer2

        if (isNaN(price) || !purpose) {
            $("#status").text("Please provide valid inputs.");
            return;
        }

        try {
            $("#partList").text("Finding Best Parts...");
            $("#submitButton").prop("disabled", true);  // Disable the submit button while fetching

            // Fetch data from the server
            let response = await fetch(`api/pricing/${price}/${purpose}`);
            if (response.ok) {
                let parts = await response.json();
                buildPartList(parts);  // Correct function call to display the data
            } else if (response.status !== 404) {
                let problemJSON = await response.json();  // Fixed typo (problemJson -> problemJSON)
                errorRtn(problemJSON, response.status);  // Corrected typo here as well
            } else {
                $("#status").text("No such path on server");
            }
        } catch (error) {
            $("#status").text(`Error: ${error.message}`);
        } finally {
            $("#submitButton").prop("disabled", false);  // Re-enable the submit button after request is completed
        }
    });

    const buildPartList = (data) => {
        $("#partList").empty(); // Clear the existing list

        // Create and append the header row
        let div = $(`<div class="list-group-item text-black bg-primary row d-flex" id="status">Parts Info</div>
        <div class="list-group-item row d-flex text-center text-primary" id="heading">
            <div class="col-4 h4">CPU</div>
            <div class="col-4 h4">CPU Fan</div>
            <div class="col-4 h4">GPU</div>
            <div class="col-4 h4">Motherboard</div>
            <div class="col-4 h4">RAM</div>
            <div class="col-4 h4">Power Supply</div>
        </div>
    `);
        div.appendTo($("#partList"));

        // Categories mapping (use the actual keys from the data)
        const categories = [
            { key: 'cpu', label: 'CPU' },
            { key: 'cpuFan', label: 'CPU Fan' },
            { key: 'gpu', label: 'GPU' },
            { key: 'motherboard', label: 'Motherboard' },
            { key: 'ram', label: 'RAM' },
            { key: 'psu', label: 'Power Supply' }
        ];

        // Iterate through each category and display its parts
        categories.forEach(category => {
            // Get the parts for this category (overBudget, underBudget)
            let categoryParts = data[category.key];
            let overBudgetParts = categoryParts ? categoryParts.overBudget : [];
            let underBudgetParts = categoryParts ? categoryParts.underBudget : [];

            // Create a new row for this category
            let categoryDiv = $('<div class="list-group-item row"></div>');

            // For overBudget parts, show only names
            let overBudgetNames = overBudgetParts.map(part => `<div class="col-4">${part.name}</div>`).join('');

            // For underBudget parts, show only names
            let underBudgetNames = underBudgetParts.map(part => `<div class="col-4">${part.name}</div>`).join('');

            // Append the overBudget and underBudget part names to the category div
            categoryDiv.append(overBudgetNames + underBudgetNames);

            // Append the category div to the part list
            $("#partList").append(categoryDiv);
        });
    };

    // Initial function call could be removed if not required to run on page load
    // buildPartList(); 
});
