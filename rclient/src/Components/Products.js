import { useEffect, useState } from 'react';
import { Button, Container, Table } from 'react-bootstrap';
import ProductModal from './ProductModal';

export const Products = () => {
  const [productList, setProductsList] = useState([]);
  const [showModal, setShowModal] = useState(false);

  const getProductsAsync = async () => {
    const response = await fetch('http://localhost:5041/api/Product');
    const products = await response.json();

    setProductsList(products);
  };

  const onCloseModal = () => setShowModal(false);

  useEffect(() => {
    getProductsAsync();
  }, []);

  return (
    <Container>
      <h1 className="mb-4 mt-4"> Inventory</h1>
      <Table striped hover>
        <thead>
          <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Price</th>
            <th>Category</th>
          </tr>
        </thead>
        <tbody>
          {productList.map((p) => {
            return (
              <tr key={p.id}>
                <td>{p.id}</td>
                <td>{p.name}</td>
                <td>{p.price}</td>
                <td>{p.categoryName}</td>
              </tr>
            );
          })}
        </tbody>
      </Table>
      <div className="d-flex justify-content-end">
        <Button variant="primary" onClick={() => setShowModal(true)}>
          Create New Product
        </Button>
      </div>

      <ProductModal show={showModal} onClose={onCloseModal} />
    </Container>
  );
};
