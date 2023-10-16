<template>
  <div style="text-align: start;">
    <h2>Selecciona tus asientos</h2>
    <div class="d-flex align-items-center flex-column">
    <div class="d-flex">
      <img src="./../assets/avionStart.png" alt="">
      <div class="seat-map">
        <div
          v-for="row in seatMap.slice(0, 3)"
          :key="row.rowLetter"
          class="seat-row"
        >
          <div
            style="width: 30px;"
            v-for="seat in row.seats"
            :key="seat.id"
            :class="{
              'seat-available': !seat.occupied && !seat.selected,
              'seat-occupied': seat.occupied,
              'seat-selected': seat.selected,
            }"
            @click="toggleSeatSelection(seat)"
          >
            {{ seat.id }}
          </div>
        </div>
        <br />
        <div
          v-for="row in seatMap.slice(3, 6)"
          :key="row.rowLetter"
          class="seat-row"
        >
          <div
            style="width: 30px;"
            v-for="seat in row.seats"
            :key="seat.id"
            :class="{
              'seat-available': !seat.occupied && !seat.selected,
              'seat-occupied': seat.occupied,
              'seat-selected': seat.selected,
            }"
            @click="toggleSeatSelection(seat)"
          >
            {{ seat.id }}
          </div>
        </div>
      </div>
      <img src="./../assets/avionEnd.png" alt="">
    </div>
    </div>
    <div class="d-flex" style="flex-direction: row; align-items: center; width: 100%; gap: 25rem;">
      <div class="d-flex" style="flex-direction: column;">
        <p>Asientos disponibles: {{ availableSeatsCount }}</p>
        <p>Asientos seleccionados: {{ selectedSeats.length }} / {{ numPasajeros }}</p>
      </div>
      <div class="d-flex" style="gap: 1rem;">
        <div class="d-flex" style="align-items: center; gap: 0.5rem;">
          <div class="d-flex" style="flex-direction: column; background-color: #ccc; width: 15px; height: 15px; border-radius: 50%;"></div>
          <div class="d-flex">No disponible</div>
        </div>
        <div class="d-flex" style="align-items: center; gap: 0.5rem;">
          <div class="d-flex" style="flex-direction: column; background-color: #4caf50; width: 15px; height: 15px; border-radius: 50%;"></div>
          <div class="d-flex">Disponible</div>
        </div>
        <div class="d-flex" style="align-items: center; gap: 0.5rem;">
          <div class="d-flex" style="flex-direction: column; background-color: darkred; width: 15px; height: 15px; border-radius: 50%;"></div>
          <div class="d-flex">Seleccionado</div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    numPasajeros: {
      type: Number
    }
  },
  data() {
    const mapData = (letter) => {
      const seats = []
      for(let i = 0; i <= 20; i++) {
        seats.push(
          { id: letter + i, occupied: Boolean(Math.round(Math.random())), selected: false },
        )
      }
      return seats;
    }
    const seatsMap = [];
    const letters = ["A", "B", "C", "D", "E", "F"];
    letters.forEach((letter) => {
      seatsMap.push({
        rowLetter: letter,
        seats: mapData(letter)
      });
    });
    
    return {
      seatMap: seatsMap,
    };
  },
  computed: {
    availableSeatsCount() {
      return this.seatMap.reduce((count, row) => {
        return count + row.seats.filter(seat => !seat.occupied).length;
      }, 0);
    },
    selectedSeats() {
      const selectedSeats = [];
      this.seatMap.forEach(row => {
        selectedSeats.push(...row.seats.filter(seat => seat.selected));
      });
      return selectedSeats;
    },
  },
  methods: {
    toggleSeatSelection(seat) {
      if (!seat.occupied) {
        seat.selected = !seat.selected;
        // Limita la selección a 5 asientos
        if (this.selectedSeats.length > this.numPasajeros) {
          seat.selected = false;
        }
      }
    },
  },
};
</script>

<style scoped>
.seat-map {
  display: flex;
  flex-direction: column;
  gap: 10px;
}

.seat-row {
  display: flex;
  flex-direction: row;
  gap: 10px;
}

.seat-available {
  background-color: #4caf50; /* Verde para asientos disponibles*/
  cursor: pointer;
  color: #fff;
}

.seat-occupied {
  background-color: #ccc; /* Gris para asientos ocupados */
  color: #000;
}

.seat-selected {
  background-color: darkred; /* Rojo oscuro para asientos seleccionados */
  cursor: pointer;
  color: #fff;
}
</style>
