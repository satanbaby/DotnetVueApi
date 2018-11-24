<template>
  <div>
    <div class="card-columns">
      
      <div class="card" v-for="item in product" :key="item.pId">
        <div class="card-body text-left">
          <h5 class="card-title">{{item.pName}}</h5>
          <p class="card-text">價格:{{item.price}}</p>
          <p class="card-text">數量:{{item.qty}}</p>
        </div>
        <div class="text-right mb-3 mr-4">
        <button type="button" class="btn btn-danger">加入購物車</button>
        </div>
      </div>
    </div>
    
  </div>
</template>
<script>
export default {
  data(){
    return{
      product:[]
    }
  },
  created() {
    let api = `${process.env.API_PATH}/api/pruduct`
    this.$http.get(api).then((response) => {
      console.log(response.data)
      this.product=response.data
    })
  },  
}
</script>
