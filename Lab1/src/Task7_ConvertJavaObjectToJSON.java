
public class Task7_ConvertJavaObjectToJSON {
    public static void main(String[] args) throws JsonProcessingException {
        Car car = new Car();
        ObjectMapper objectMapper = new ObjectMapper();

        car.setBrand("BMW");
        car.setModel("S3");
        car.setManufacturerYear(2021);

        String carJSON = objectMapper.writeValueAsString(car);
        System.out.println("Model as JSON: " + carJSON);
    }
}
