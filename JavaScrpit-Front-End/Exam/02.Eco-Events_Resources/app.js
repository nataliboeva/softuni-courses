function solve() {
    const formElements = {
        email: document.getElementById("email"),
        event: document.getElementById("event"),
        location: document.getElementById("location"),
        submitButton: document.getElementById("next-btn")
    };

    const lists = {
        preview: document.getElementById("preview-list"),
        approved: document.getElementById("event-list")
    };

    formElements.submitButton.addEventListener("click", handleSubmission);

    function handleSubmission(e) {
        e.preventDefault();

        const formData = {
            email: formElements.email.value,
            event: formElements.event.value,
            location: formElements.location.value
        };

        if (!formData.email || !formData.event || !formData.location) return;

        const eventEntry = createEventEntry(formData);
        lists.preview.appendChild(eventEntry);
        
        clearForm();
        formElements.submitButton.disabled = true;
    }

    function createEventEntry(data) {
        const entry = document.createElement("li");
        entry.className = "application";

        const content = createEntryContent(data);
        entry.appendChild(content);

        const editControl = createButton("edit", "Edit", () => {
            restoreFormData(data);
            lists.preview.removeChild(entry);
            formElements.submitButton.disabled = false;
        });

        const applyControl = createButton("apply", "Apply", () => {
            while (entry.querySelector('button')) {
                entry.removeChild(entry.querySelector('button'));
            }
            lists.approved.appendChild(entry);
            formElements.submitButton.disabled = false;
        });

        entry.appendChild(editControl);
        entry.appendChild(applyControl);
        
        return entry;
    }

    function createEntryContent(data) {
        const content = document.createElement("article");
        
        const emailHeader = document.createElement("h4");
        emailHeader.textContent = data.email;

        const eventDetails = document.createElement("p");
        eventDetails.textContent = "Event:" + data.event;

        const locationDetails = document.createElement("p");
        locationDetails.textContent = "Location:" + data.location;

        content.appendChild(emailHeader);
        content.appendChild(eventDetails);
        content.appendChild(locationDetails);
        return content;
    }

    function createButton(className, text, handler) {
        const button = document.createElement("button");
        button.className = "action-btn " + className;
        button.textContent = text;
        button.addEventListener("click", handler);
        return button;
    }

    function clearForm() {
        Array.from(Object.values(formElements)).forEach(element => {
            if (element.tagName === "INPUT") {
                element.value = "";
            }
        });
    }

    function restoreFormData(data) {
        formElements.email.value = data.email;
        formElements.event.value = data.event;
        formElements.location.value = data.location;
    }

    function validateForm() {
        const isValid = Array.from(Object.values(formElements))
            .filter(element => element.tagName === "INPUT")
            .every(input => input.value.trim());
        formElements.submitButton.disabled = !isValid;
    }

    Array.from(Object.values(formElements))
        .filter(element => element.tagName === "INPUT")
        .forEach(input => input.addEventListener("input", validateForm));
}
