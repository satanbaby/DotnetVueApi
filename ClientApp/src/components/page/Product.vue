<template>
  <div>
    <h1 class="text-left">產品列表</h1>
    <hr>
    <div class="card-columns mt-5">
      
      <div class="card" v-for="item in product" :key="item.pId">
        <div class="card-body text-left">
          <h5 class="card-title">{{item.pName}}</h5>
          <p class="card-text">價格:{{item.price}}</p>
          <p class="card-text">數量:{{item.qty}}</p>
        </div>
        <div class="card-footer">
          <div class="input-group">
            <div class="input-group-prepend">
              <label class="input-group-text" for="inputGroupSelect01">數量</label>
            </div>
            <select class="custom-select mr-4" id="inputGroupSelect01" 
            @change="selectQty(item.pId)">
              <option v-if="qtys<10" v-for="(qtys, index) in item.qty"
              :value="qtys" :key="index">{{qtys}}</option>
            </select>
          
          <button type="button" class="btn btn-danger"
          @click="addShopCar(item)">加入購物車</button>
          </div>
        
        </div>
      </div>
    </div>
  
  </div>
</template>
<script>

export default {
  data(){
    return{
      product:[],
      shopCar:[],
    }
  },
  methods:{
    selectQty(id,qty=1){
      console.log(id,qty)
    },
    addShopCar(item){
      let vm = this
      let api = `${process.env.API_PATH}/api/pruduct/${item.pId}`
      console.log(item)
      this.$http.get(api).then((response) => {
        //vm.shopCar.push(response.data)
        
      })
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
