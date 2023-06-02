const API_URL = 'https://localhost:7079/graphql'; // URL de tu API de GraphQL
const heroFields = document.querySelectorAll('input[name="field"]');
const queryButton = document.getElementById('query-button');
const resultsDiv = document.getElementById('results');

queryButton.addEventListener('click', fetchData);

async function fetchData() {
  // Obtener los campos seleccionados
  const selectedFields = Array.from(heroFields)
    .filter(field => field.checked)
    .map(field => field.value);

  // Construir la consulta GraphQL según los campos seleccionados
  const query = `
    query {
      heroes {
        ${selectedFields.join('\n')}
      }
    }
  `;

  try {
    const response = await fetch(API_URL, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ query })
    });

    if (!response.ok) {
      throw new Error('Error en la respuesta de la API');
    }

    const { data } = await response.json();
    const heroes = data.heroes;

    displayHeroes(heroes);

  } catch (error) {
    console.error('Error al llamar a la API:', error);
  }
}

function displayHeroes(heroes) {
    const heroesList = document.getElementById('heroes-list');
    heroesList.innerHTML = '';
  
    heroes.forEach(hero => {
      const heroContainer = document.createElement('div');
      heroContainer.classList.add('hero-container');
  
      const nameElement = document.createElement('h3');
      nameElement.textContent = hero.nombre;
      heroContainer.appendChild(nameElement);
  
      // Agregar más campos según los seleccionados
      if (hero.habilidades) {
        const abilitiesElement = document.createElement('p');
        abilitiesElement.textContent = 'Habilidades: ' + hero.habilidades;
        heroContainer.appendChild(abilitiesElement);
      }
  
      if (hero.debilidades) {
        const weaknessesElement = document.createElement('p');
        weaknessesElement.textContent = 'Debilidades: ' + hero.debilidades;
        heroContainer.appendChild(weaknessesElement);
      }

      if (hero.relacionesPersonales) {
        const relationshipsElement = document.createElement('p');
        relationshipsElement.textContent = 'Relaciones Personales: ' + hero.relacionesPersonales;
        heroContainer.appendChild(relationshipsElement);
      }
  
      if (hero.edad) {
        const ageElement = document.createElement('p');
        ageElement.textContent = 'Edad: ' + hero.edad;
        heroContainer.appendChild(ageElement);
      }
  
      heroesList.appendChild(heroContainer);
    });
  }
  
