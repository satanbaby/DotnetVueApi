<template>
  <div>
    <h1 class="text-left mb-5">訂單管理</h1>
    <table class="table table-striped">
      <thead>
        <tr>
          <th scope="col">產品編號</th>
          <th scope="col">購買人姓名</th>
          <th scope="col">產品名稱</th>
          <th scope="col">產品價格</th>
          <th scope="col">購買數量</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="item in order" :key="item.uId">
          <td>{{item.oId}}</td>
          <td>{{item.uName}}</td>
          <td>{{item.pName}}</td>
          <td>{{item.price}}</td>
          <td>{{item.orderQty}}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>
<script>
export default {
  data() {
    return {
      order: []
    };
  },
  created() {
    let api = `${process.env.API_PATH}/api/orders`;
    this.$http.get(api).then(response => {
      console.log(response.data.data);
      this.order = response.data.data;
    });
  }
};
</script>
