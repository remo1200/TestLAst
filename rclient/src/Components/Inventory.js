import { useEffect, useState } from 'react';
import { Container, Table } from 'react-bootstrap';

export const Inventory = () => {
  const [productList, setProductsList] = useState([]);
  const [categoryList, setCategoryList] = useState([]);

  const getInventoriesAsync = async (selectedCategory) => {
    const response = await fetch(
      `http://localhost:5041/api/Inventory/${selectedCategory}`
    );
    const products = await response.json();

    setProductsList(products);
  };

  const getCategoriesAsync = async () => {
    const response = await fetch('http://localhost:5041/api/category');
    const categories = await response.json();

    setCategoryList(categories);
  };

  useEffect(() => {
    getCategoriesAsync();
  }, []);

  return (
    <Container>
      <h1 className="mb-4 mt-4"> Inventory</h1>

      <select
        className="form-control mb-4"
        onChange={(e) => getInventoriesAsync(e.target.value)}
      >
        <option value={0}>Select An Option</option>

        {categoryList.map((c) => {
          return (
            <option key={c.id} value={c.id}>
              {c.name}
            </option>
          );
        })}
      </select>

      <Table striped hover>
        <thead>
          <tr>
            <th>Id</th>
            <th>Product</th>
            <th>Price</th>
            <th>Quantity</th>
            <th>Category</th>
          </tr>
        </thead>
        <tbody>
          {productList.map((i) => {
            return (
              <tr key={i.id}>
                <td>{i.productId}</td>
                <td>{i.product}</td>
                <td>{i.price}</td>
                <td>{i.quantity}</td>
                <td>{i.category}</td>
              </tr>
            );
          })}
        </tbody>
      </Table>
    </Container>
  );
};
