<template>
  <div class="container text-center" v-if="loading">
    <div class="row">
      <div class="col-sm-2">
        <div class="sp sp-circle"></div>
      </div>
    </div>
  </div>
</template>

<script lang="ts" setup>
defineProps({
  loading: { 
    type: Boolean,
    required: false
  },
});
</script>

<style scoped lang="scss">
$spCol: #e21515;

.col-sm-2 {
	padding: 10px;
	border-radius: 4px;
	height: 125px;
	margin-bottom: 10px;
}

.sp {
	width: 32px;
	height: 32px;
	clear: both;
	margin: 20px auto;
}

/* Spinner Circle Rotation */
.sp-circle {
	border: 4px rgba($spCol,0.25) solid;
	border-top: 4px rgba($spCol,1) solid;
	border-radius: 50%;
	-webkit-animation: spCircRot .6s infinite linear;
	animation: spCircRot .6s infinite linear;
}
@-webkit-keyframes spCircRot {
	from { -webkit-transform: rotate(0deg); }
	to { -webkit-transform: rotate(359deg); }
}
@keyframes spCircRot {
	from { transform: rotate(0deg); }
	to { transform: rotate(359deg); }
}
</style>