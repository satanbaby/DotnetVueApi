<template>
  <div>
    <h1 class="text-left mb-5">購物車</h1>
    <table class="table">
      <thead>
        <tr>
          <th scope="col">#</th>
          <th scope="col">產品名稱</th>
          <th scope="col">產品價格</th>
          <th scope="col">購買數量</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(item,index) in product" :key="item.uId">
          <th scope="row">{{index+1}}</th>
          <td>{{item.pName}}</td>
          <td>{{item.price}}</td>
          <td>{{item.qty}}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>
<script>
export default {
  data() {
    return {
      product: []
    };
  },
  created() {
    let api = `${process.env.API_PATH}/api/pruduct`;
    this.$http.get(api).then(response => {
      console.log(response);
      this.product = response.data;
    });
  }
};
</script>
