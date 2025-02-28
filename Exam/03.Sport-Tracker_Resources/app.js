function setupWorkoutManager() {
    const endpoints = {
        base: 'http://localhost:3030/jsonstore/workout/'
    };

    const dom = {
        inputs: {
            workout: document.getElementById('workout'),
            location: document.getElementById('location'),
            date: document.getElementById('date')
        },
        buttons: {
            load: document.getElementById('load-workout'),
            add: document.getElementById('add-workout'),
            edit: document.getElementById('edit-workout')
        },
        container: document.getElementById('list')
    };

    let currentWorkoutId = null;

    // Event Listeners
    dom.buttons.load.addEventListener('click', loadAllWorkouts);
    dom.buttons.add.addEventListener('click', createWorkout);
    dom.buttons.edit.addEventListener('click', updateWorkout);
    dom.buttons.edit.disabled = true;

    async function loadAllWorkouts() {
        try {
            const response = await fetch(endpoints.base);
            const data = await response.json();
            
            dom.container.innerHTML = '';
            Object.values(data).forEach(renderWorkout);
        } catch (err) {
            console.error('Failed to load:', err);
        }
    }

    function renderWorkout(data) {
        const workoutElement = document.createElement('div');
        workoutElement.className = 'container';

        const titleElement = document.createElement('h2');
        titleElement.textContent = data.workout;

        const dateElement = document.createElement('h3');
        dateElement.textContent = data.date;

        const locationElement = document.createElement('h3');
        locationElement.id = 'location';
        locationElement.textContent = data.location;

        const controls = document.createElement('div');
        controls.id = 'buttons-container';

        const editBtn = document.createElement('button');
        editBtn.className = 'change-btn';
        editBtn.textContent = 'Change';

        const removeBtn = document.createElement('button');
        removeBtn.className = 'delete-btn';
        removeBtn.textContent = 'Delete';

        controls.appendChild(editBtn);
        controls.appendChild(removeBtn);

        workoutElement.appendChild(titleElement);
        workoutElement.appendChild(dateElement);
        workoutElement.appendChild(locationElement);
        workoutElement.appendChild(controls);

        editBtn.addEventListener('click', () => {
            fillEditForm(data);
            workoutElement.remove();
        });

        removeBtn.addEventListener('click', () => removeWorkout(data._id));

        dom.container.appendChild(workoutElement);
    }

    async function createWorkout() {
        const data = getFormData();
        if (!validateData(data)) return;

        try {
            await fetch(endpoints.base, {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(data)
            });
            clearForm();
            loadAllWorkouts();
        } catch (err) {
            console.error('Failed to create:', err);
        }
    }

    async function updateWorkout() {
        if (!currentWorkoutId) return;

        const data = getFormData();
        if (!validateData(data)) return;

        try {
            await fetch(endpoints.base + currentWorkoutId, {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(data)
            });
            
            currentWorkoutId = null;
            dom.buttons.edit.disabled = true;
            dom.buttons.add.disabled = false;
            clearForm();
            loadAllWorkouts();
        } catch (err) {
            console.error('Failed to update:', err);
        }
    }

    async function removeWorkout(id) {
        try {
            await fetch(endpoints.base + id, { method: 'DELETE' });
            loadAllWorkouts();
        } catch (err) {
            console.error('Failed to remove:', err);
        }
    }

    function fillEditForm(data) {
        dom.inputs.workout.value = data.workout;
        dom.inputs.location.value = data.location;
        dom.inputs.date.value = data.date;
        currentWorkoutId = data._id;
        dom.buttons.edit.disabled = false;
        dom.buttons.add.disabled = true;
    }

    function getFormData() {
        return {
            workout: dom.inputs.workout.value.trim(),
            location: dom.inputs.location.value.trim(),
            date: dom.inputs.date.value
        };
    }

    function validateData(data) {
        return Object.values(data).every(val => val);
    }

    function clearForm() {
        Object.values(dom.inputs).forEach(input => input.value = '');
    }
}

setupWorkoutManager();
